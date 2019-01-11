using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamics365AutoMapper.DataTypes {
    public class CRMDataType {
        public static Dictionary<string, Type> Dictionary = new Dictionary<string, Type>() {
            {"OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts", typeof(OptionSetValue)},
            {"EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts", typeof(EntityReference)},
        };
    }
}
