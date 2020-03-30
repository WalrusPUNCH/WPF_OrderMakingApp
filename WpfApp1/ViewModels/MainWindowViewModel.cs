using System;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Presentation_Layer.Interfaces;
using Presentation_Layer.EntityViewModels;
using Presentation_Layer.Utilities;

using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Utilities;

namespace Presentation_Layer.ViewModels
{
    public class MainWindowViewModel : IMainWindowVM
    {
        private readonly IMVMMapper Mapper;
        private readonly IModel Model;
        private ObservableCollection<DishViewModel> DishesForNextOrder = new ObservableCollection<DishViewModel>();

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

        private ICommand _addDishToOrderCommand;
        public ICommand AddDishToOrderCommand {
            get
            {
                return _addDishToOrderCommand ?? (_addDishToOrderCommand = new Command(dish =>
                {
                    bool? isAdding = dish as bool?;
                    if (isAdding != null)
                        if (isAdding == true)
                            DishesForNextOrder.Add(ChosenDish);
                        else
                            if (DishesForNextOrder.Contains(ChosenDish))
                                DishesForNextOrder.Remove(ChosenDish);
                }));
            }
        }

        private ICommand _makeOrderCommand;
        public ICommand MakeOrderCommand
        {
            get
            {
                return _makeOrderCommand ?? (_makeOrderCommand = new Command(obj =>
                {
                    Model.ConfirmOrder(Mapper.MapViewModelOnMenu(DishesForNextOrder));
                    DishesForNextOrder.Clear();
                    foreach (DishViewModel dish in Menu)
                        dish.IsOrdered = false;
                }));
            }
        }

        private ICommand _showOKDialogCommand;
        public ICommand ShowOKDialogCommand
        {
            get
            {
                return _showOKDialogCommand ?? (_showOKDialogCommand = new Command( (dynamic info) =>
                {
                    var dialogService = (Application.Current as App).DialogService_;
                    var OkDialogViewModel = new OKDialogViewModel(info.Title, info.Message);
                    dialogService.CreateWindow(OkDialogViewModel).ShowDialog();
                }));
            }
        }
 
        private ICommand _openAdminPanelCommand;
        public ICommand OpenAdminPanelCommand
        {
            get
            {
                return _openAdminPanelCommand ?? (_openAdminPanelCommand = new Command(obj =>
                {
                    var dialogService = (Application.Current as App).DialogService_;
                    var AdminPanelViewModel = new AdminViewModel(Menu, Model, Mapper);
                    dialogService.CreateWindow(AdminPanelViewModel).ShowDialog();
                }));
            }
        }
        public MainWindowViewModel(IModel model, IMVMMapper mapper)
        {
            Model = model;
            Mapper = mapper;

            Model.OrderConfirmed += Model_OrderConfirmed;
            menu = new ObservableCollection<DishViewModel>(Mapper.MapMenuOnViewModel(Model.GetMenu()));
            Mapper.Menu = Model.GetMenu();
        }

        private void Model_OrderConfirmed(object sender, OrderEventArgs e)
        {
            string response = FormResponse(e.ConfirmedOrder);
            ShowOKDialogCommand.Execute(new { Title = "Ваше замовлення", Message = response });
        }

        private string FormResponse(Order order)
        {
            string response = String.Format("Ваше замовлення буде готове о {0}\n", order.ServingTime.ToShortTimeString());
            foreach (CookedDish dish in order.CookedDishes)
                response += String.Format("Страва {0} буде готова о {1} \n", dish.Information.Name, dish.CookedAt.ToShortTimeString());
            return response;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
