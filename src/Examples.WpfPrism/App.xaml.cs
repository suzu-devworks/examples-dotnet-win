using System.Windows;
using Examples.WpfPrism.ViewModels;
using Examples.WpfPrism.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;

namespace Examples.WpfPrism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
            => Container.Resolve<Views.MainWindow>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SampleView, SampleViewModel>();

            containerRegistry.RegisterDialogWindow<DefaultWindow>();
            containerRegistry.RegisterDialogWindow<GreenWindow>("greenWindow");
            containerRegistry.RegisterDialogWindow<BlueWindow>("blueWindow");
            containerRegistry.RegisterDialog<SampleDialog, SampleDialogViewModel>();

            return;
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
        }
    }
}
