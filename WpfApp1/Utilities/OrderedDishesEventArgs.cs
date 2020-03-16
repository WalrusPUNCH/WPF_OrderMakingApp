using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_OrderMakingApp.Utilities
{
    public class OrderedDishesEventArgs : EventArgs
    {
        public List<string> OrderedDishesName { get; set; }
        public OrderedDishesEventArgs(List<string> dishes)
        {
            OrderedDishesName = dishes;
        }
    }
}
