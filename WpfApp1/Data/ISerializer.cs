using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_OrderMakingApp
{
    public interface ISerialize
    {
        void Serialize<T>(IEnumerable<T> list, string path);
    }

    public interface IDeserialize
    {
        IEnumerable<T> Deserialize<T>(string path);
    }

    public interface ISerializer : ISerialize, IDeserialize
    {

    }
}
