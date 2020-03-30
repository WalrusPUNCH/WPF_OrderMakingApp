using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_OrderMakingApp.ADataLayer.Entities;
using WPF_OrderMakingApp.Model;
using WPF_OrderMakingApp.Utilities;
using WPF_OrderMakingApp.ViewModel;
using WPF_OrderMakingApp.View;
using AutoMapper;

namespace WPF_OrderMakingApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public readonly DialogService DialogService_ = new DialogService();
        public readonly Container IoCContainer = new Container();
        public App()
        {
            ConfigureDialogService();   
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();

            ConfigureIoCContainer();

            IMainWindowVM mainWindowVM = IoCContainer.Create<IMainWindowVM>();
            mainWindow.DataContext = mainWindowVM;

            mainWindow.Show();
        }

        private void ConfigureDialogService()
        {
            DialogService_.RegisterType<MainWindowViewModel, MainWindow>();
            DialogService_.RegisterType<OKDialogViewModel, OKDialog>();
            DialogService_.RegisterType<AdminViewModel, AdminView>();
        }


        private void ConfigureIoCContainer()
        {
            IoCContainer.Register<IMainWindowVM, MainWindowViewModel>();
            IoCContainer.Register<IModel, Kitchen>();
            IoCContainer.Register<IMVMMapper, MVMMapper>();
            IoCContainer.Register<ADataLayer.Interfaces.IUnitOfWork, ADataLayer.UnitOfWork>();
            IoCContainer.Register<ADataLayer.Interfaces.IKitchenContext, ADataLayer.Contexts.KitchenContext>();
      
            IoCContainer.RegisterImplementation<IMapper>(ConfigureMapper().CreateMapper());
        }

        private MapperConfiguration ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg => 
                                                { cfg.CreateMap<DishEntity, Dish>()
                                                   .ForMember("Cuisine", opt => opt.MapFrom(entity => (Specialization)entity.Cuisine))
                                                   .ForMember("ID", opt => opt.MapFrom(entity => entity.ID.ToString()));

                                                   cfg.CreateMap<CookEntity, Cook>()
                                                    .ForMember("Qualification_", opt => opt.MapFrom(entity => (Qualification)entity.Qualification_))
                                                    .ForMember("Specialization_", opt => opt.MapFrom(entity => (Specialization)entity.Specialization_))
                                                    .ForMember("ID", opt => opt.MapFrom(entity => entity.ID.ToString()));

                                                    cfg.CreateMap<Cook, CookEntity>();
                                                    cfg.CreateMap<Dish, DishEntity>();

                                                }) ;
           
            return config;
        }
    }
}
