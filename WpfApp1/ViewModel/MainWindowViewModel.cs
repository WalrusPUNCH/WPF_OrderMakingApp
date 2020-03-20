using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_OrderMakingApp.Model;
using WPF_OrderMakingApp.Utilities;

namespace WPF_OrderMakingApp.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged, IMainWindowVM
    {
        private readonly IMVMConverter MVMConverter;

        private readonly IModel Model;     

        private ObservableCollection<DishViewModel> menu;
        public ObservableCollection<DishViewModel> Menu
        {
            get => menu;
        }

        private DishViewModel chosenDish;
        public DishViewModel ChosenDish
        {
            get => chosenDish;
            set
            {
                chosenDish = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<DishViewModel> dishesForNextOrder = new ObservableCollection<DishViewModel>();

        public ICommand AddDishToOrderCommand { get; private set; }

        public ICommand MakeOrderCommand { get; private set; }

        public ICommand ShowOKDialogCommand { get; private set; }


        public MainWindowViewModel(IModel model)
        {
            Model = model;
            MVMConverter = new ModelViewModelConverter(Model.GetMenu());

            Model.OrderConfirmed += Model_OrderConfirmed;
            menu = new ObservableCollection<DishViewModel>(MVMConverter.ConvertModelToViewModel(Model.GetMenu()));
           // menu = new ObservableCollection<DishViewModel>(ConvertModelToViewModel(Model.GetMenu()));

            AddDishToOrderCommand = new Command(_ => AddDishToOrder());
            MakeOrderCommand = new Command(_ => VM_MakeOrder());
            //ShowOKDialogCommand = new Command(_ => ShowOKDialog());
        }

        private void Model_OrderConfirmed(object sender, Utilities.OrderEventArgs e)
        {
            string response = FormResponse(e.ConfirmedOrder);
            ShowOKDialog("Ваше замовлення", response);
            //MessageBox.Show(response);
        }

        private string FormResponse(Order order)
        {
            string response = String.Format("Ваше замовлення буде готове о {0}\n", order.ServingTime.ToShortTimeString());
            foreach (Dish dish in order.OrderedDishes)
                response += String.Format("Страва {0} буде готова о {1} \n", dish.Name, dish.CookedAt.ToShortTimeString());
            return response;
        }

        private void ClearOrderedDishes()
        {
            dishesForNextOrder.Clear();
            foreach (DishViewModel dish in Menu)
                dish.IsOrdered = false;
        }

        private void AddDishToOrder()
        {
            dishesForNextOrder.Add(chosenDish);
        }

        private void VM_MakeOrder()
        {
            Model.ConfirmOrder(MVMConverter.ConvertViewModelToModel(dishesForNextOrder));
            ClearOrderedDishes();
        }

        private void ShowOKDialog(string title, string message)
        {
            var dialogService = (Application.Current as App).DialogService_;
            var otherWindowViewModel = new OKDialogViewModel(title, message);
            dialogService.CreateWindow(otherWindowViewModel).ShowDialog();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
