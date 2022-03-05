using System.Windows;
using Prism.Services.Dialogs;

namespace Examples.WpfPrism.Views
{
    /// <summary>
    /// GreenWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class GreenWindow : Window, IDialogWindow
    {
        public GreenWindow()
        {
            InitializeComponent();
        }

        public IDialogResult? Result { get; set; }

    }
}
