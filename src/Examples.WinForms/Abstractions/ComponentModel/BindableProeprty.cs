using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Examples.WinForms.Abstractions.ComponentModel
{
    [DefaultProperty("Value")]
    public class BindableProeprty<T> : INotifyPropertyChanged
    {

        public BindableProeprty()
        { }

        public BindableProeprty(INotifyPropertyChanged sender, string name)
        {
        }

        private static readonly PropertyChangedEventArgs eventArgs = new(nameof(Value));

        public event PropertyChangedEventHandler PropertyChanged;

        private T _backingStore;

        public T Value
        {
            get { return _backingStore; }
            set
            {
                if (object.Equals(_backingStore, value))
                {
                    return;
                }

                _backingStore = value;
                PropertyChanged?.Invoke(this, eventArgs);
                foreach (var a in actions)
                {
                    a.Invoke(this);
                }
            }
        }

        public BindableProeprty<T> AddPropertyChangedAction(Action<dynamic> p)
        {
            actions.Add(p);
            return this;
        }

        private readonly List<Action<dynamic>> actions = new();

    }
}
