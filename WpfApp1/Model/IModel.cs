using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMakingApp
{
    interface IModel
    {
        event EventHandler<OrderEventArgs> OrderConfirmed;
        void ConfirmOrder(List<string> dishes);
        List<Dish> GetMenu();
    }
}
