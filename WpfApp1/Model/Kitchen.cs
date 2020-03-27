using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using WPF_OrderMakingApp.Utilities;
using WPF_OrderMakingApp.Data;

using Data_Layer;

namespace WPF_OrderMakingApp.Model
{
    public class Kitchen : IModel, INotifyPropertyChanged, IChangeable
    {
        public event EventHandler<OrderEventArgs> OrderConfirmed = delegate { };
        private readonly IDataLayer dataAccess;
        List<Cook> Cooks = new List<Cook>();
        private List<Data_Layer.Entities.DishEntity> list = new List<Data_Layer.Entities.DishEntity>();
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
            list = new Data_Layer.Repositories.MenuRepository(new Data_Layer.DishContext()).GetMenu().ToList();
            dataAccess = data;

            Menu = dataAccess.GetItems<Dish>().ToList();
            Cooks = dataAccess.GetItems<Cook>().ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public void ConfirmOrder(IEnumerable<Dish> DishesToCook)
        {
            List<CookedDish> cookedDishes = new List<CookedDish>();
            DateTime ServingTime = DateTime.Now;
            foreach (Dish dish in DishesToCook)
            {
                List<Cook> AvaliableCooks = Cooks.Where(cook => cook.Specialization_ == dish.Cuisine).ToList();
                AvaliableCooks.Sort();
               // AvaliableCooks = AvaliableCooks.OrderBy(cook => cook.EndOfWorkTime).ThenByDescending(cook => (int)((Qualification)Enum.Parse(typeof(Qualification), cook.Qualification_.ToString()))).ToList();
                try
                {
                    DateTime cookTime = AvaliableCooks.First().CookDish(dish);
                    cookedDishes.Add(new CookedDish(dish, cookTime));
                   // dish.CookedAt = cookTime;
                    if (cookTime > ServingTime)
                        ServingTime = cookTime;
                }
                catch (NullReferenceException)
                {
                    OrderConfirmed(this, new OrderEventArgs(new Order(cookedDishes, DateTime.MinValue)));
                }
            }
            OrderConfirmed(this, new OrderEventArgs(new Order(cookedDishes, ServingTime)));
        }

        public void AddDish(Dish dish)
        {
            Menu.Add(dish);
        }
        public void RemoveDish(Dish dish)
        {
            Menu.Remove(dish);
        }

        public List<Dish> GetMenu()
        {
            return Menu;
        }
    }
}
