using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_OrderMakingApp.Model;
using WPF_OrderMakingApp.ViewModel;

namespace WPF_OrderMakingApp.Utilities
{
    public interface IMVMConverter
    {
        IEnumerable<Dish> ConvertViewModelToModel(IEnumerable<DishViewModel> dishViewModels);
        IEnumerable<DishViewModel> ConvertModelToViewModel(IEnumerable<Dish> dishes);

    }
}
