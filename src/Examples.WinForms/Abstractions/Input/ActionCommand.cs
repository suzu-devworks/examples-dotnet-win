using System;
using System.Windows.Input;

namespace Examples.WinForms.Abstractions.Input
{
    public class ActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ActionCommand(Action<ActionCommand> action, bool enabled = true)
        {
            _CommandAction = action;
            _Enabled = enabled;
        }

        private readonly Action<ActionCommand> _CommandAction;

        public bool Enabled
        {
            get { return _Enabled; }
            set
            {
                if (_Enabled != value)
                {
                    _Enabled = value;
                    RaiseCanExecuteChanged();
                }
            }
        }
        private bool _Enabled;

        public bool CanExecute(object _)
        {
            return Enabled;
        }

        public void Execute(object _)
        {
            _CommandAction.Invoke(this);
        }

        protected void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
