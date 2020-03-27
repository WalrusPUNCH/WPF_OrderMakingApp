using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_OrderMakingApp.Model;

namespace WPF_OrderMakingApp.ViewModel
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private IChangeable Kitchen;
        private IMVMMapper Mapper;

        public ObservableCollection<DishViewModel> Menu { get; private set; }
        private DishViewModel selectedDish;
        public DishViewModel SelectedDish
        {
            get => selectedDish;
            set
            {
                selectedDish = value;
                OnPropertyChanged();
            }
        }

        private ICommand _addDishCommand;
        public ICommand AddDishCommand
        {
            get
            {
                return _addDishCommand ?? (_addDishCommand = new Command(obj =>
                {
                    Dish NewDish = new Dish();
                    DishViewModel NewDishVM = new DishViewModel(NewDish);
                    SelectedDish = NewDishVM;
                    Menu.Insert(0, NewDishVM);
                    Kitchen.AddDish(NewDish);
                }));
            }
        }

        private ICommand _removeDishCommand;
        public ICommand RemoveDishCommand
        {
            get
            {
                return (_removeDishCommand ?? (_removeDishCommand = new Command(obj =>
                {
                    if (SelectedDish != null)
                    {
                        Kitchen.RemoveDish(Mapper.MapViewModelOnDish(SelectedDish));
                        Menu.Remove(SelectedDish);
                    }
                })));
            }
        }
        
        
        public AdminViewModel(ObservableCollection<DishViewModel>  menu, IChangeable kitchen, IMVMMapper mapper)
        {
            Kitchen = kitchen;
            Menu = menu;
            Mapper = mapper;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
