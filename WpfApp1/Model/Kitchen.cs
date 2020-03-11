using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OrderMakingApp
{
    public class Kitchen : IModel
    {
        public event EventHandler<OrderEventArgs> OrderConfirmed = delegate { };
        private readonly IDataLayer dataAccess;
        List<Cook> Cooks = new List<Cook>();
        private List<Dish> Menu { get; set; } = new List<Dish>();
        public Kitchen(IDataLayer data)
        {
            dataAccess = data;

            Menu = dataAccess.GetItems<Dish>().ToList();
            Cooks = dataAccess.GetItems<Cook>().ToList();

           // Cooks = @base.GetCooks();
           // Menu = @base.GetMenu();
        }

        public void ConfirmOrder(List<string> DishNamesToCook)
        {
            List<Dish> DishesToCook = ConvertNamesToRealDishes(DishNamesToCook);

            DateTime ServingTime = DateTime.Now;
            foreach (Dish dish in DishesToCook)
            {
                List<Cook> AvaliableCooks = Cooks.Where(cook => cook.Specialization_ == dish.Cuisine).ToList();
                AvaliableCooks.Sort();
               // AvaliableCooks = AvaliableCooks.OrderBy(cook => cook.EndOfWorkTime).ThenByDescending(cook => (int)((Qualification)Enum.Parse(typeof(Qualification), cook.Qualification_.ToString()))).ToList();
                try
                {
                    DateTime DishReadyTime = AvaliableCooks.First().CookDish(dish);
                    if (DishReadyTime > ServingTime)
                        ServingTime = DishReadyTime;
                }
                catch (NullReferenceException)
                {
                    OrderConfirmed(this, new OrderEventArgs(new Order(DishesToCook, DateTime.MinValue)));
                }
            }
            OrderConfirmed(this, new OrderEventArgs(new Order(DishesToCook, ServingTime)));
        }

        private List<Dish> ConvertNamesToRealDishes(List<string> DishNames)
        {
            List<Dish> dishes = new List<Dish>();
            foreach (string dishName in DishNames)
                dishes.Add(Menu.Where(dish => dish.Name == dishName).First());
            return dishes;
        }

        public List<Dish> GetMenu()
        {
            return Menu;
        }
    }
}
