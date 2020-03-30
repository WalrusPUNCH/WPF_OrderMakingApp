using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class Order
    {
        public readonly IEnumerable<CookedDish> CookedDishes = new List<CookedDish>();
        public readonly DateTime ServingTime;
        public readonly float Weight = 0;

        public Order(IEnumerable<CookedDish> dishes, DateTime time)
        {
            CookedDishes = dishes;
            ServingTime = time; 
            foreach (CookedDish dish in CookedDishes)
                Weight += dish.Information.WeightInGrams;
        }

    }
}
