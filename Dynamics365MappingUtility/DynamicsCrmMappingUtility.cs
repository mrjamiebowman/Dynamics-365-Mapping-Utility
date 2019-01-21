using DynamicsCrmMappingUtility.Attributes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using DynamicsCrmMappingUtility.DataTypes;
using Microsoft.Xrm.Sdk;
using DynamicsCrmMappingUtility.Models;
using Microsoft.Xrm.Sdk.Query;
using System.Linq.Expressions;
using DynamicsCrmMappingUtility.Errors;

namespace DynamicsCrmMappingUtility
{
    public class DynamicsCrmMappingUtility<T> where T : class
    {
        public delegate void CustomMappingMethodDelegate(T model, Type customFieldMap, PropertyInfo property, object value);

        public static CustomMappingMethodDelegate CustomMappingMethod { get; set; }

        /// <summary>
        /// MapToModel (WebHook) - Maps WebHook data to model.
        /// </summary>
        /// <param name="image">WebHook Target, PreImage, or PostImage</param>
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
                            throw new DynamicsCrmMappingUtilityError($"The custom mapping method for '{crmAttr.CustomFieldMap}' has not been set.");
                        }

                        CustomMappingMethod(model, crmAttr.CustomFieldMap, prop, attr.value);
                        continue;
                    }

                    // Simple Fields: Single Line of Text, Option Set, Two Options, Image, Whole Number, Floating Point Number, Decimal Number, Currency, Multiple Lines of Text, Date and Time, Lookup

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
                            if (prop.PropertyType == typeof(CRMStateType?) || prop.PropertyType == typeof(CRMStateType)) {
                                CRMStateType state;
                                if (Enum.TryParse<CRMStateType>(json["Value"].ToString(), out state)) {
                                    prop.SetValue(model, state);
                                } else {
                                    prop.SetValue(model, null);
                                }                                
                            } else {
                                prop.SetValue(model, (int?)json["Value"]);
                            }                            
                        } else if (crmDataType == typeof(Money)) {
                            prop.SetValue(model, (decimal?)json["Value"]);
                        }
                    }
                } /* end foreach */
            }

            return model;
        }

        #region Private Methods

        private static List<PropertyInfo> GetFieldByFieldName(string fieldName) {
            var publicProps = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            List<PropertyInfo> properties = (publicProps.Where(x => x.CustomAttributes.Any(ca =>
                (ca.AttributeType == typeof(CRMAttribute)) &&
                ca.NamedArguments.Any(na => na.TypedValue.Value.ToString() == fieldName)))).ToList();
            return properties;
        }

        private static PropertyInfo GetPropertyFromExpression(Expression<Func<T, object>> GetPropertyLambda) {
            MemberExpression Exp = null;

            //this line is necessary, because sometimes the expression comes in as Convert(originalexpression)
            if (GetPropertyLambda.Body is UnaryExpression) {
                var UnExp = (UnaryExpression)GetPropertyLambda.Body;
                if (UnExp.Operand is MemberExpression) {
                    Exp = (MemberExpression)UnExp.Operand;
                } else
                    throw new ArgumentException();
            } else if (GetPropertyLambda.Body is MemberExpression) {
                Exp = (MemberExpression)GetPropertyLambda.Body;
            } else {
                throw new ArgumentException();
            }

            return (PropertyInfo)Exp.Member;
        }

        private static MemberInfo GetPropertyInfoFromExpression(Expression expression) {
            if (expression == null) {
                throw new ArgumentException("Expression is null.");
            }

            if (expression is MemberExpression) {
                var memberExpression = (MemberExpression)expression;
                return memberExpression.Member;
            }

            if (expression is MethodCallExpression) {
                // Reference type method
                var methodCallExpression = (MethodCallExpression)expression;
                return methodCallExpression.Method;
            }

            if (expression is UnaryExpression) {
                // Property, field of method returning value type
                var unaryExpression = (UnaryExpression)expression;
                if (unaryExpression.Operand is MemberExpression) {
                    return ((MemberExpression)unaryExpression.Operand).Member;
                } else {
                    throw new ArgumentException();
                }
            }

            throw new ArgumentException("ArgumentException");
        }

        private static System.Attribute GetAttributeFromExpression(Expression expression, Type attrType) {
            if (expression == null) {
                throw new ArgumentException("Expression is null.");
            }

            if (expression is MemberExpression) {
                // Reference type property or field
                var memberExpression = (MemberExpression)expression;
                return memberExpression.Member.GetCustomAttribute(attrType);
            }

            if (expression is MethodCallExpression) {
                // Reference type method
                var methodCallExpression = (MethodCallExpression)expression;
                return methodCallExpression.Method.GetCustomAttribute(attrType);
            }

            if (expression is UnaryExpression) {
                // Property, field of method returning value type
                var unaryExpression = (UnaryExpression)expression;
                return GetAttributeFromExpression(unaryExpression, attrType);
            }

            throw new ArgumentException("ArgumentException");
        }

        private static System.Attribute GetAttributeFromExpression(UnaryExpression unaryExpression, Type attrType) {
            if (unaryExpression.Operand is MethodCallExpression) {
                var methodExpression = (MethodCallExpression)unaryExpression.Operand;
                return methodExpression.Method.GetCustomAttribute(attrType);
            }

            return ((MemberExpression)unaryExpression.Operand).Member.GetCustomAttribute(attrType);
        }

        #endregion

        #region Legacy Methods

        /// <summary>
        /// Legacy: GetColumnSetByFields - returns a ColumnSet based on properties selected.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static ColumnSet GetColumnSetByFields(params Expression<Func<T, Object>>[] fields) {
            ColumnSet columns = new ColumnSet();

            foreach (var obj in fields) {
                CRMAttribute attr = GetAttributeFromExpression(obj?.Body, typeof(CRMAttribute)) as CRMAttribute;

                if (attr != null) {
                    columns.AddColumn(attr.FieldName);
                }
            }

            return columns;
        }

        /// <summary>
        /// Legacy: MapToEntity - will map model class data to Xrm Entity.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static Entity MapToEntity(T model, Entity entity = null, params Expression<Func<T, Object>>[] fields) {
            if (entity == null) {
                entity = new Entity();
                CRMEntityAttribute crmEntAtt = typeof(T).GetCustomAttribute(typeof(CRMEntityAttribute)) as CRMEntityAttribute;
                entity.LogicalName = crmEntAtt.EntityLogicalName;
            }

            // validation
            if (String.IsNullOrWhiteSpace(entity.LogicalName)) {
                throw new NullReferenceException("Entity Logical Name not set.");
            }

            Func<Entity, PropertyInfo, CRMAttribute, Entity> mapToEntity = (Entity ent, PropertyInfo prop, CRMAttribute attr) => {
                if (!String.IsNullOrWhiteSpace(attr.FieldName)) {
                    entity[attr.FieldName] = prop.GetValue(model);
                }

                // TODO: complex data objects like EntityReference, OptionSets

                return ent;
            };

            // get properties from model
            List<PropertyInfo> modelProperties;
            if (fields != null) {
                foreach (var obj in fields) {
                    CRMAttribute attr = GetAttributeFromExpression(obj?.Body, typeof(CRMAttribute)) as CRMAttribute;
                    PropertyInfo prop = (PropertyInfo)GetPropertyInfoFromExpression(obj.Body);
                    entity = mapToEntity(entity, prop, attr);
                }
            } else {
                // default to all
                modelProperties = model.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();

                foreach (PropertyInfo prop in modelProperties) {
                    CRMAttribute attr = prop.GetCustomAttribute<CRMAttribute>();
                    entity = mapToEntity(entity, prop, attr);
                }
            }

            return entity;
        }

        /// <summary>
        /// Legacy: MapToModel - will map Xrm Entity data to model class.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T MapToModel(Entity entity, T model) {

            return model;
        }

        #endregion
    }
}
