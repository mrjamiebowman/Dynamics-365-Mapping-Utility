using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicsCrmMappingUtility.Attributes {
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CRMEntityAttribute : System.Attribute {
        public string EntityLogicalName;

        public CRMEntityAttribute() {

        }

        public CRMEntityAttribute(string entityLogicalName) {
            this.EntityLogicalName = entityLogicalName;
        }
    }
}
