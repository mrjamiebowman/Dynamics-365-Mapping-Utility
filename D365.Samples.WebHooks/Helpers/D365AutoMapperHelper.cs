using Dynamics365AutoMapper.Enums;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace D365.Samples.WebHooks.Helpers {
    public class D365AutoMapperHelper {
        private static void CustomMapping<T>(T model, Type customFieldMap, PropertyInfo property, object value) where T : class {
            if (customFieldMap == typeof(CustomerTypeCode?)) {
                // CustomerTypeCodeType?
                OptionSetValue optSet = ((JObject)value).ToObject<OptionSetValue>();
                property.SetValue(model, (CustomerTypeCode)optSet.Value);
            }
        }
    }
}
