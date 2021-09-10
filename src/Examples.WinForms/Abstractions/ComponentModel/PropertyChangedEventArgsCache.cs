using System.Collections.Generic;
using System.ComponentModel;

namespace Examples.WinForms.Abstractions.ComponentModel
{
    public class PropertyChangedEventArgsCache
    {
        private readonly Dictionary<string, PropertyChangedEventArgs> _Cache = new();

        // TODO Cache Expire.

        public PropertyChangedEventArgs Get(string propertyName)
        {
            if (!_Cache.TryGetValue(propertyName, out var eventArgs))
            {
                eventArgs = new PropertyChangedEventArgs(propertyName);
                _Cache.Add(propertyName, eventArgs);
            }
            return eventArgs;
        }
    }
}
