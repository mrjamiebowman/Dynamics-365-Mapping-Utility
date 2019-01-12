using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicsCrmMappingUtility.Attributes {
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CRMAttribute : System.Attribute {
        public string FieldName;
        public Type CustomFieldMap;

        public CRMAttribute() {

        }

        public CRMAttribute(string fieldName, Type customFieldMap) {
            this.FieldName = fieldName;
            this.CustomFieldMap = customFieldMap;
        }
    }
}
