using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMakingApp
{
    public interface IDataLayer
    {
        IEnumerable<T> GetItems<T>();
    }
}
