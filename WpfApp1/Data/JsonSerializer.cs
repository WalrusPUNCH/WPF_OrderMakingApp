using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using Newtonsoft.Json.Converters;


namespace OrderMakingApp
{
    class JsonSerializer : ISerialize, IDeserialize
    {
        Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

        public void Serialize<T>(IEnumerable<T> items, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, items);
            }
        }

        public IEnumerable<T> Deserialize<T>(string filePath)
        {
            IEnumerable<T> list = new List<T>();
            using (StreamReader sr = new StreamReader(filePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                list = (IEnumerable<T>)serializer.Deserialize(reader, typeof(IEnumerable<T>));
            }
            return list;
        }
    }
}
