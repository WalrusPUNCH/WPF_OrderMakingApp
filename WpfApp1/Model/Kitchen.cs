using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPF_OrderMakingApp.Utilities;
using WPF_OrderMakingApp.Data;

namespace WPF_OrderMakingApp.Model
{
    public class Kitchen : IModel, INotifyPropertyChanged
    {
        public event EventHandler<OrderEventArgs> OrderConfirmed = delegate { };
        private readonly IDataLayer dataAccess;
        List<Cook> Cooks = new List<Cook>();
        private List<Dish> menu = new List<Dish>();
        public List<Dish> Menu
        {
            get => menu;
            private set
            {
                menu = value;
                OnPropertyChanged();
            }
        }
        public Kitchen(IDataLayer data)
        {
            dataAccess = data;

            Menu = dataAccess.GetItems<Dish>().ToList();
            Cooks = dataAccess.GetItems<Cook>().ToList();

           // Cooks = @base.GetCooks();
           // Menu = @base.GetMenu();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public void ConfirmOrder(IEnumerable<Dish> DishesToCook)
        {
            DateTime ServingTime = DateTime.Now;
            List<DishInfo> InfoAboutOrderedDishes = new List<DishInfo>();
            foreach (Dish dish in DishesToCook)
            {
                List<Cook> AvaliableCooks = Cooks.Where(cook => cook.Specialization_ == dish.Cuisine).ToList();
                AvaliableCooks.Sort();
               // AvaliableCooks = AvaliableCooks.OrderBy(cook => cook.EndOfWorkTime).ThenByDescending(cook => (int)((Qualification)Enum.Parse(typeof(Qualification), cook.Qualification_.ToString()))).ToList();
                try
                {
                    DishInfo InfoAboutDish = AvaliableCooks.First().CookDish(dish);
                    if (InfoAboutDish.CookedAt > ServingTime)
                        ServingTime = InfoAboutDish.CookedAt;
                    InfoAboutOrderedDishes.Add(InfoAboutDish);
                }
                catch (NullReferenceException)
                {
                    OrderConfirmed(this, new OrderEventArgs(new Order(InfoAboutOrderedDishes, DateTime.MinValue)));
                }
            }
            OrderConfirmed(this, new OrderEventArgs(new Order(InfoAboutOrderedDishes, ServingTime)));
        }

        public List<Dish> GetMenu()
        {
            return Menu;
        }
    }
}
