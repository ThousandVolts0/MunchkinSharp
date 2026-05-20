using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Munchkin.Registries
{
    public interface IRegistry<T>
    {
        void Register(string identifier, T obj);
        void Unregister(string identifier);
        T this[string identifier] { get; }
        IReadOnlyList<T> GetAll();
    }
}
