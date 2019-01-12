using D365.Samples.WebHooks.Enums;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace D365.Samples.WebHooks.Helpers {
    public class CustomAutoMapsHelper {
        public static void CustomMapping<T>(T model, Type customFieldMap, PropertyInfo property, object value) where T : class {
            if (customFieldMap == typeof(CustomerTypeCodeType?)) {
                // CustomerTypeCodeType?
                OptionSetValue optSet = ((JObject)value).ToObject<OptionSetValue>();
                property.SetValue(model, (CustomerTypeCodeType)optSet.Value);
            }
        }
    }
}
