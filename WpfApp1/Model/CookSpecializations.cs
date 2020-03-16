using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace WPF_OrderMakingApp.Model
{
    public enum Specialization
    {
        [JsonConverter(typeof(StringEnumConverter))]
        European = 0,
        [JsonConverter(typeof(StringEnumConverter))]
        American = 1,
        [JsonConverter(typeof(StringEnumConverter))]
        Asian = 2
    }
}
