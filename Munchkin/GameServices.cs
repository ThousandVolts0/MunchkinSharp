using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin
{
    public class GameServices
    {
        private readonly Dictionary<Type, object> _services = new();

        public void Register<T>(T service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            _services[typeof(T)] = service;
        }

        public void Unregister<T>()
        {
            _services.Remove(typeof(T));
        }

        public T Get<T>()
        {
            return (T)_services[typeof(T)];
        }
    }
}
