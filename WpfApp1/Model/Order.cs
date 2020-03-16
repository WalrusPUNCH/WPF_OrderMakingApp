using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_OrderMakingApp.Utilities;

namespace WPF_OrderMakingApp.Model
{
    public class Order
    {
        public readonly IEnumerable<DishInfo> OrderedDishes = new List<DishInfo>();
        public readonly DateTime ServingTime;
        public readonly float Weight = 0;

        public Order(IEnumerable<DishInfo> dishes, DateTime time)
        {
            OrderedDishes = dishes;
            ServingTime = time; 
            foreach (DishInfo dish in dishes)
                Weight += dish.Dish_.WeightInGrams;
        }

    }
}
