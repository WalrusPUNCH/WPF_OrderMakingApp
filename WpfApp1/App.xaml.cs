using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_OrderMakingApp.Data;
using WPF_OrderMakingApp.Model;
using WPF_OrderMakingApp.Utilities;
using WPF_OrderMakingApp.ViewModel;
using WPF_OrderMakingApp.View;

namespace WPF_OrderMakingApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DialogService DialogService_ = new DialogService();
        public Container IoCContainer = new Container();
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
            //IoCContainer.Register<IMVMConverter, ModelViewModelConverter>();
            IoCContainer.Register<IMVMMapper, MVMMapper>();
            IoCContainer.Register<IDataLayer, DataLayer>();
            IoCContainer.Register<ISerialize, JsonSerializer>();
            IoCContainer.Register<IDeserialize, JsonSerializer>();
            IoCContainer.Register<ISerializer, JsonSerializer>();
        }
    }
}
