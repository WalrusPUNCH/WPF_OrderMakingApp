using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace OrderMakingApp
{
    public enum Qualification
    {
        [JsonConverter(typeof(StringEnumConverter))]
        Junior = 10,
        [JsonConverter(typeof(StringEnumConverter))]
        Middle = 15,
        [JsonConverter(typeof(StringEnumConverter))]
        Senior = 20
    }
}
