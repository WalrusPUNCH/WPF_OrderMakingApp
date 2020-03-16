using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_OrderMakingApp.Model;

namespace WPF_OrderMakingApp.Utilities
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
