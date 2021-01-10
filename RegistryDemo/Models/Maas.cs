using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace RegistryDemo.Models
{
    public class Maas
    {
        public string name { get; set; }
        public string version { get; set; }
        public string platform { get; set; }
        public string min_platform { get; set; }
        public string source { get; set; }
        public string jurisdiction { get; set; }
        public string user_authn { get; set; }
        public long date { get; set; }
        public string url { get; set; }
        public string trust_registry { get; set; }
    }

    public class JsonHelpers
    {
        //  Deserialize JSON into C# Object/Type Dynamically  https://www.thecodebuzz.com/system-text-json-deserialize-json-csharp-object-type-dynamically/
        public static T GetJsonGenericType<T>(string strJson)
        {
            var generatedType = JsonSerializer.Deserialize<T>(strJson);
            return (T)Convert.ChangeType(generatedType, typeof(T));
        }
    }
}
