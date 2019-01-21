using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicsCrmMappingUtility.Tests.Helpers {
    public static class WebHookHelper 
    {
        public static JObject LoadWebHookData(string filename) {
            string dirpath = Directory.GetCurrentDirectory();
            string data = File.ReadAllText($"{dirpath}\\WEBHOOKDATA\\{filename}");
            return (JObject)JObject.Parse(data);
        }
    }
}
