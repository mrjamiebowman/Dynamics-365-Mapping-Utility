using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamics365AutoMapper.Attributes {
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
