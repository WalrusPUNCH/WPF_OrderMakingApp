using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Business_Logic_Layer.Utilities;
using Business_Logic_Layer.Models;

namespace Business_Logic_Layer.Interfaces
{
    public interface IModel : IChangeable
    {
        event EventHandler<OrderEventArgs> OrderConfirmed;
        void ConfirmOrder(IEnumerable<Dish> dishNames);
        List<Dish> GetMenu();        
    }

}
