using System.Windows.Forms;
using System.Windows.Input;

namespace Examples.WinForms.Extensions
{
    public static class ICommandExtensions
    {
        public static void Bind(this Button button, ICommand command)
        {
            button.Enabled = command.CanExecute(null);
            button.Click += (s, e) => command.Execute(null);

            command.CanExecuteChanged += (s, e) => { button.Enabled = command.CanExecute(null); };

            return;
        }
    }
}
