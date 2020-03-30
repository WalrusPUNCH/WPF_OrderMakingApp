using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

using Presentation_Layer.EntityViewModels;

namespace Presentation_Layer.Interfaces
{
    public interface IMainWindowVM : INotifyPropertyChanged
    {
        ObservableCollection<DishViewModel> Menu { get; }
        DishViewModel ChosenDish { get; set; }
        ICommand AddDishToOrderCommand { get; }
        ICommand MakeOrderCommand { get; }
        ICommand ShowOKDialogCommand { get; }

    }
}
