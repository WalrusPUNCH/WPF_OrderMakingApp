using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities
{
    public class DishEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TimeSpan CookingTime { get; set; }
        public Specialization Cuisine { get; set; }
        public float WeightInGrams { get; set; }
    }
}
