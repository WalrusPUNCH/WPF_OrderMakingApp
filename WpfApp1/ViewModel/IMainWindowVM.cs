using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_OrderMakingApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace WPF_OrderMakingApp.ViewModel
{
    public interface IMainWindowVM : INotifyPropertyChanged
    {
        ObservableCollection<DishViewModel> Menu { get; }
        ICommand AddDishToOrderCommand { get; }
        ICommand MakeOrderCommand { get; }
        ICommand ShowOKDialogCommand { get; }

    }
}
