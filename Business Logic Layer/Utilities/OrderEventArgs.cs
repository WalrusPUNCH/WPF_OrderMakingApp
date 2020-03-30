using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic_Layer.Models;

namespace Business_Logic_Layer.Utilities
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
