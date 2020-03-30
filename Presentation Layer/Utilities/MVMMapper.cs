using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Presentation_Layer.Interfaces;
using Presentation_Layer.EntityViewModels;
using Business_Logic_Layer.Models;

namespace Presentation_Layer.Utilities
{
    public class MVMMapper : IMVMMapper
    {
        public IEnumerable<Dish> Menu { private get; set; }

        public IEnumerable<DishViewModel> MapMenuOnViewModel(IEnumerable<Dish> items)
        {
            if (items == null)
                return null;
            IEnumerable<DishViewModel> dishVMs = new List<DishViewModel>();
            foreach (Dish dish in items)
                dishVMs = dishVMs.Append(new DishViewModel(dish));
            return dishVMs.Reverse();
        }

        public IEnumerable<Dish> MapViewModelOnMenu(IEnumerable<DishViewModel> items)
        {
            IEnumerable<Dish> dishes = new List<Dish>();
            foreach (DishViewModel dishVM in items)
                dishes = dishes.Append(Menu.Where(dish => dish.ID == dishVM.ID).First());
            return dishes.Reverse();
        }

        public DishViewModel MapDishOnVIewModel(Dish dish)
        {
            return new DishViewModel(dish);
        }
        public Dish MapViewModelOnDish(DishViewModel dishVM)
        {
            return Menu.Where(dish => dish.ID == dishVM.ID).First();
        }
    }
}
