using Dynamics365AutoMapper.Attributes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Dynamics365AutoMapper.DataTypes;
using Microsoft.Xrm.Sdk;
using Dynamics365AutoMapper.Models;
using Microsoft.Xrm.Sdk.Query;
using System.Linq.Expressions;

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

        public static ColumnSet GetColumnSetByProperties(params Expression<Func<T, object>>[] fields) {
            ColumnSet columns = new ColumnSet();

            PropertyInfo[] modelProps = typeof(T).GetProperties();

            foreach (var field in fields) {
                string test = "";
            }
            
            return columns;
        }

        public static Entity MapToEntity(T model, Entity entity = null, params Expression<Func<T, object>>[] fields) {            
            if (entity == null) {
                entity = new Entity();
                CRMEntityAttribute crmEntAtt = typeof(T).GetCustomAttribute(typeof(CRMEntityAttribute)) as CRMEntityAttribute;
                entity.LogicalName = crmEntAtt.EntityLogicalName;
            }

            // validation
            if (String.IsNullOrWhiteSpace(entity.LogicalName)) {
                throw new NullReferenceException("Entity Logical Name not set.");
            }

            // TODO: get all properties from crm model

            // TODO: read metadata

            // TODO: map to entity

            return entity;
        }

        public static T MapToModel(Entity entity, T model) {

            return model;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image">WebHook: Target, PreImage, or PostImage</param>
        /// <param name="model">Model with CRM Attributes for metadata mapping</param>
        /// <returns></returns>
        public static T MapToModel(JObject image, T model) {
            List<AttributeModel> attributes = image["Attributes"].ToObject<List<AttributeModel>>();

            foreach (AttributeModel attr in attributes) {
                List <PropertyInfo> props = GetFieldByFieldName(attr.key.ToString());

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
                        if (prop.PropertyType == typeof(Guid?) || prop.PropertyType == typeof(Guid)) {
                            prop.SetValue(model, new Guid(attr.value.ToString()));
                        } else {
                            prop.SetValue(model, attr.value);
                        }
                    } else if (attr.value.GetType() == typeof(int?) || attr.value.GetType() == typeof(int)) {
                        // int
                        prop.SetValue(model, (int)attr.value);
                    } else if (attr.value.GetType() == typeof(bool?) || attr.value.GetType() == typeof(bool)) {
                        // bool
                        prop.SetValue(model, (bool)attr.value);
                    } else if (attr.value.GetType() == typeof(DateTime?) || attr.value.GetType() == typeof(DateTime)) {
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
