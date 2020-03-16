using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_OrderMakingApp.Utilities;

namespace WPF_OrderMakingApp.Model
{
    public interface IModel
    {
        event EventHandler<OrderEventArgs> OrderConfirmed;
        void ConfirmOrder(IEnumerable<Dish> dishes);
        List<Dish> GetMenu();
    }
}
