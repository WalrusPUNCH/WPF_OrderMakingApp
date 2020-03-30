using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Presentation_Layer.EntityViewModels;
using Business_Logic_Layer.Models;

namespace Presentation_Layer.Interfaces
{
    public interface IMVMMapper
    {
        IEnumerable<Dish> Menu { set; }
        IEnumerable<DishViewModel> MapMenuOnViewModel(IEnumerable<Dish> items);
        IEnumerable<Dish> MapViewModelOnMenu(IEnumerable<DishViewModel> items);
        DishViewModel MapDishOnVIewModel(Dish dish);
        Dish MapViewModelOnDish(DishViewModel dishVM);
    }
}
