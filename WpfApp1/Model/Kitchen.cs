using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using WPF_OrderMakingApp.Utilities;
using WPF_OrderMakingApp.ADataLayer.Interfaces;

using AutoMapper;

namespace WPF_OrderMakingApp.Model
{
    public class Kitchen : INotifyPropertyChanged, IModel
    {
        public event EventHandler<OrderEventArgs> OrderConfirmed = delegate { };
        private readonly IUnitOfWork Data;
        private readonly IMapper Mapper;
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
        public Kitchen(IUnitOfWork data, IMapper mapper)
        {
            Mapper = mapper;
            Data = data;

            Menu = Mapper.Map<List<Dish>>(Data.Dishes.GetMenu());
            Cooks = Mapper.Map<List<Cook>>(Data.Cookers.GetCookers());
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
            Data.Dishes.AddDish(Mapper.Map<ADataLayer.Entities.DishEntity>(dish));
            Data.Save();
        }

        public void RemoveDish(Dish dish)
        {
            Menu.Remove(dish);
            Data.Dishes.DeleteDish(Mapper.Map<ADataLayer.Entities.DishEntity>(dish));
            Data.Save();
        }

        public void UpdateDish(Dish dish)
        {
            Data.Dishes.UpdateDish(Mapper.Map<ADataLayer.Entities.DishEntity>(dish));
            Data.Save();
        }
        public List<Dish> GetMenu()
        {
            return Menu;
        }
    }
}
