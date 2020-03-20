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
        public readonly IEnumerable<Dish> OrderedDishes = new List<Dish>();
        public readonly DateTime ServingTime;
        public readonly float Weight = 0;

        public Order(IEnumerable<Dish> dishes, DateTime time)
        {
            OrderedDishes = dishes;
            ServingTime = time; 
            foreach (Dish dish in dishes)
                Weight += dish.WeightInGrams;
        }

    }
}
