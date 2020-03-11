using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMakingApp
{
    public class Order
    {
        public readonly List<Dish> OrderedDishes = new List<Dish>();
        public readonly DateTime ServingTime;
        public readonly float Weight = 0;

        public Order(List<Dish> dishes, DateTime time)
        {
            OrderedDishes = dishes;
            ServingTime = time; 
            foreach (Dish dish in dishes)
                Weight += dish.WeightInGrams;
        }

    }
}
