using System.Windows;
using Prism.Services.Dialogs;

namespace Examples.WpfPrism.Views
{
    /// <summary>
    /// DefaultWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class DefaultWindow : Window, IDialogWindow
    {
        public DefaultWindow()
        {
            InitializeComponent();
        }

        public IDialogResult? Result { get; set; }

    }
}
