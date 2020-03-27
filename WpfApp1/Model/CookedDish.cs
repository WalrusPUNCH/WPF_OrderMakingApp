using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_OrderMakingApp.Model
{ 
    public class CookedDish
    {
        public Dish Information { get; private set; }

        private DateTime cookedAt = DateTime.MinValue;
        public DateTime CookedAt
        {
            get => cookedAt;

            private set
            {
                if (value > DateTime.Now)
                    cookedAt = value;
            }
        }

        public CookedDish(Dish dish, DateTime time)
        {
            Information = dish;
            cookedAt = time;
        }
    }
}
