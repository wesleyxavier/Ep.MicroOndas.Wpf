using Ep.MicroOndas.Ioc;
using Ninject;
using System.Windows;

namespace Ep.MicroOndas.Wpf
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IKernel container = new StandardKernel();

            container.Injecao();

            container.Bind<IMainWindow>().To<MainWindow>();

            var mainWindowViewModel = container.Get<MainWindow>();

            Current.MainWindow = mainWindowViewModel;

            Current.MainWindow.Show();
        }
    }
}
