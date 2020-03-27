using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_OrderMakingApp.ViewModel
{
    public interface IMVMMapper
    {
        IEnumerable<Model.Dish> Menu { set; }
        IEnumerable<DishViewModel> MapMenuOnViewModel(IEnumerable<Model.Dish> items);
        IEnumerable<Model.Dish> MapViewModelOnMenu(IEnumerable<DishViewModel> items);
        DishViewModel MapDishOnVIewModel(Model.Dish dish);
        Model.Dish MapViewModelOnDish(DishViewModel dishVM);
    }
}
