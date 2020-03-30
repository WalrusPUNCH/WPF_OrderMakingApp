using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using AutoMapper;

using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Entities;

using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;

using Presentation_Layer.Interfaces;
using Presentation_Layer.Utilities;
using Presentation_Layer.Views;
using Presentation_Layer.ViewModels;

namespace Presentation_Layer
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
            IoCContainer.Register<IModel, Business_Logic_Layer.Kitchen>();
            IoCContainer.Register<IMVMMapper, MVMMapper>();
            IoCContainer.Register<IUnitOfWork, Data_Access_Layer.UnitOfWork>();
            IoCContainer.Register<IKitchenContext, Data_Access_Layer.Contexts.KitchenContext>();
      
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
