using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Examples.WinForms.Abstractions.ComponentModel
{
    public abstract class BindableObject : INotifyPropertyChanged
    {
        // Required INotifyPropertyChanged because it seems to leak memory.
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly PropertyChangedEventArgsCache _PropertyChangedEventArgsCache = new();

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, _PropertyChangedEventArgsCache.Get(propertyName));
        }

        protected bool SetProperty<T>(ref T backingstore, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(backingstore, value))
            {
                return false;
            }

            backingstore = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        protected bool SetProperty<T>(ref T backingstore, T value, Action raiseEvents, [CallerMemberName] string propertyName = null)
        {
            if (SetProperty(ref backingstore, value, propertyName))
            {
                raiseEvents.Invoke();
            }
            return true;
        }
    }
}
