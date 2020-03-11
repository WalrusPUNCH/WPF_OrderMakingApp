using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrderMakingApp
{
    public class Dish
    {
        public string Name { get; private set; }
        [JsonProperty]
        public Specialization Cuisine { get; private set; }
        public TimeSpan CookingTime { get; private set; }
        [JsonProperty]
        public float WeightInGrams { get; private set; }
        public List<Ingridient> Ingridients { get; private set; }

        private DateTime cookedAt = DateTime.MinValue;
        public DateTime CookedAt
        {
            get => cookedAt;

            set
            {
                if (value > DateTime.Now)
                    cookedAt = value;
            }
        }

        public Dish(string name, Specialization spec, TimeSpan cookingTime, float weight, List<Ingridient> ingridients)
        {
            Name = name;
            Cuisine = spec;
            CookingTime = cookingTime;
            WeightInGrams = weight;
            Ingridients = ingridients;
        }

    }
}
