using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_OrderMakingApp.Data
{
    public interface IDataLayer
    {
        IEnumerable<T> GetItems<T>();
    }
}
