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
namespace WPF_OrderMakingApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();

            var container = new Container();

            container.Register<IMainWindowVM, MainWindowViewModel>();
            container.Register<IModel, Kitchen>();
            container.Register<IDataLayer, DataLayer>();
            container.Register<ISerialize, JsonSerializer>();
            container.Register<IDeserialize, JsonSerializer>();
            container.Register<ISerializer, JsonSerializer>();

            IMainWindowVM mainWindowVM = container.Create<IMainWindowVM>();
            mainWindow.DataContext = mainWindowVM;

            mainWindow.Show();
        }
    }
}
