using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMakingApp
{
    public class OrderEventArgs : EventArgs
    {
        public Order ConfirmedOrder { get; set; }
        public OrderEventArgs(Order order)
        {
            ConfirmedOrder = order;
        }
    }
}
