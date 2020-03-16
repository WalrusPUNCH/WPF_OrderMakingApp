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

namespace WPF_OrderMakingApp.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged, IMainWindowVM
    {
        private readonly IModel Model;     

        private ObservableCollection<Dish> menu;
        public ObservableCollection<Dish> Menu
        {
            get => menu;
        }

        private Dish chosenDish;
        public Dish ChosenDish
        {
            get => chosenDish;
            set
            {
                chosenDish = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Dish> dishesForNextOrder = new ObservableCollection<Dish>();

        public ICommand AddDishToOrderCommand { get; private set; }

        public ICommand MakeOrderCommand { get; private set; }

        public ICommand AlertCommand { get; private set; }


        public MainWindowViewModel(IModel model)
        {
            Model = model;
            Model.OrderConfirmed += Model_OrderConfirmed;
            menu = new ObservableCollection<Dish>(Model.GetMenu());

            AddDishToOrderCommand = new Command(_ => AddDishToOrder());
            MakeOrderCommand = new Command(_ => VM_MakeOrder());
            AlertCommand = new Command(_ => MakeAlert());

        }

        private void Model_OrderConfirmed(object sender, Utilities.OrderEventArgs e)
        {
            string response = FormResponse(e.ConfirmedOrder);
            MessageBox.Show(response);
        }
        private string FormResponse(Order order)
        {
            string response = String.Format("Ваше замовлення буде готове о {0}\n", order.ServingTime.ToShortTimeString());
            foreach (DishInfo dish in order.OrderedDishes)
                response += String.Format("Страва {0} буде готова о {1} \n", dish.Dish_.Name, dish.CookedAt.ToShortTimeString());
            return response;
        }

        private void ClearOrderedDishes()
        {
            dishesForNextOrder.Clear();
            foreach (Dish dish in Menu)
                dish.IsOrdered = false;
        }

        private void AddDishToOrder()
        {
            dishesForNextOrder.Add(chosenDish);
        }

        private void VM_MakeOrder()
        {
            Model.ConfirmOrder(dishesForNextOrder);
            ClearOrderedDishes();
        }

        private void MakeAlert()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
