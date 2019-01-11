using Dynamics365AutoMapper.Attributes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Dynamics365AutoMapper.DataTypes;
using Microsoft.Xrm.Sdk;
using Dynamics365AutoMapper.Models;

namespace Dynamics365AutoMapper {
    public class DynamicsCrmAutoMapper<T> where T : class {
        public delegate void CustomMappingMethodDelegate(T model, Type customFieldMap, PropertyInfo property, object value);

        public static CustomMappingMethodDelegate CustomMappingMethod { get; set; }

        private static List<PropertyInfo> GetFieldByFieldName(string fieldName) {
            var publicProps = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            List<PropertyInfo> properties = (publicProps.Where(x => x.CustomAttributes.Any(ca =>
                (ca.AttributeType == typeof(CRMAttribute)) &&
                ca.NamedArguments.Any(na => na.TypedValue.Value.ToString() == fieldName)))).ToList();
            return properties;
        }

        public static T MapDataCrmToModel(Value3 postImage, T model) {
            foreach (Attribute2 attr in postImage.Attributes) {
                List<PropertyInfo> props = GetFieldByFieldName(attr.key);

                foreach (PropertyInfo prop in props) {
                    if (prop == null) {
                        continue;
                    }

                    // get custom attribute
                    CRMAttribute crmAttr = prop.GetCustomAttributes().SingleOrDefault(x => x.GetType() == typeof(CRMAttribute)) as CRMAttribute;

                    // manually map first
                    if (crmAttr.CustomFieldMap != null) {
                        if (CustomMappingMethod == null) {
                            throw new InvalidOperationException($"The custom mapping method for '{crmAttr.CustomFieldMap}' has not been set.");
                        }

                        CustomMappingMethod(model, crmAttr.CustomFieldMap, prop, attr.value);
                        continue;
                    }

                    // automap properties
                    if (attr.value.GetType() == typeof(String)) {
                        // string
                        if (prop.PropertyType == typeof(Guid)) {
                            prop.SetValue(model, new Guid(attr.value.ToString()));
                        } else {
                            prop.SetValue(model, attr.value);
                        }
                    } else if (attr.value.GetType() == typeof(int) || attr.value.GetType() == typeof(Int64)) {
                        // int
                        prop.SetValue(model, (int)attr.value);
                    } else if (attr.value.GetType() == typeof(bool)) {
                        // bool
                        prop.SetValue(model, (bool)attr.value);
                    } else if (attr.value.GetType() == typeof(DateTime)) {
                        // datetime
                        prop.SetValue(model, (DateTime)attr.value);
                    } else if (attr.value.GetType() == typeof(JObject)) {
                        // copmlex data types
                        JObject json = ((JObject)attr.value);
                        string dataType = (string)json["__type"];
                        Type crmDataType = CRMDataType.Dictionary[dataType];

                        // entity reference
                        if (crmDataType == typeof(EntityReference)) {
                            // EntityReference
                            if (prop.PropertyType == typeof(String)) {
                                prop.SetValue(model, (String)json["Name"]);
                            } else if (prop.PropertyType == typeof(Guid) || prop.PropertyType == typeof(Guid?)) {
                                prop.SetValue(model, (Guid)json["Id"]);
                            }
                        } else if (crmDataType == typeof(OptionSetValue)) {
                            string test = "";
                        }
                    }
                } /* end foreach */
            }

            return model;
        }
    }
}
