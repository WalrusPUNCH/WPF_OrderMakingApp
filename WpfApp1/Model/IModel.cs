using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WPF_OrderMakingApp.Utilities;

namespace WPF_OrderMakingApp.Model
{
    public interface IModel : IChangeable
    {
        event EventHandler<OrderEventArgs> OrderConfirmed;
        void ConfirmOrder(IEnumerable<Dish> dishNames);
        List<Dish> GetMenu();        
    }

}
