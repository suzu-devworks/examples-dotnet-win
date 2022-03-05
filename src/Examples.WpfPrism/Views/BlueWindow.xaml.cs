using System.Windows;
using Prism.Services.Dialogs;

namespace Examples.WpfPrism.Views
{
    /// <summary>
    /// BlueWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class BlueWindow : Window, IDialogWindow
    {
        public BlueWindow()
        {
            InitializeComponent();
        }

        public IDialogResult? Result { get; set; }

    }
}
