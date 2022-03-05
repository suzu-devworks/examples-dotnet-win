using Prism.Mvvm;
using Prism.Regions;

namespace Examples.WpfPrism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string? _title = "WPF Prism example!";
        public string? Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            this._regionManager.RegisterViewWithRegion("ContentRegion", typeof(Views.SampleView));
        }
    }
}
