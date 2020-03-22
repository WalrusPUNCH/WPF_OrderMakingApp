using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WPF_OrderMakingApp.Model;
using WPF_OrderMakingApp.ViewModel;

namespace WPF_OrderMakingApp.Utilities
{
    public class ModelViewModelConverter : IMVMConverter
    {
        private IEnumerable<Dish> Menu { get; set; }
        public ModelViewModelConverter(IEnumerable<Dish> dishes)
        {
            Menu = dishes;
        }

        public IEnumerable<Dish> ConvertViewModelToModel(IEnumerable<DishViewModel> dishViewModels)
        {
            if (dishViewModels == null)
                return null;
            IEnumerable<Dish> dishes = new List<Dish>();
            foreach (DishViewModel dishVM in dishViewModels)
                dishes = dishes.Append(Menu.Where(dish => dish.Name == dishVM.Name).First());
            return dishes.Reverse();
        }

        public IEnumerable<DishViewModel> ConvertModelToViewModel(IEnumerable<Dish> dishes)
        {
            if (dishes == null)
                return null;
            IEnumerable<DishViewModel> dishVMs = new List<DishViewModel>();
            foreach (Dish dish in dishes)
                dishVMs = dishVMs.Append(new DishViewModel(dish.Name, dish.Cuisine.ToString(), dish.CookingTime, dish.WeightInGrams));
            return dishVMs.Reverse();
        }
    }
}
