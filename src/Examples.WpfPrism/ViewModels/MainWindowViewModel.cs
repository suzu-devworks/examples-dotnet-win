using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace Examples.WpfPrism.ViewModels
{
    public class MainWindowViewModel: BindableBase
    {
        public string? Title => "WPF Prism example!";
    }
}
