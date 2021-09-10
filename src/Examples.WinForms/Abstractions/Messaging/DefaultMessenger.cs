using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examples.WinForms.Views;

namespace Examples.WinForms.Abstractions.Messaging
{
    public class DefaultMessenger : IMessenger
    {
        internal void Send()
        {
            throw new NotImplementedException();
        }

        internal Task SendAsync()
        {
            foreach (var action in callbacks.AsParallel())
            {
                action();
            }

            return Task.CompletedTask;
        }

        internal void Register(object recipient, Action callback)
        {
            //TODO Weak Reference;
            callbacks.Add(callback);
        }

        private readonly List<Action> callbacks = new();

    }
}
