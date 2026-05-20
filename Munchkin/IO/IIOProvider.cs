using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.IO
{
    public interface IIOProvider
    {
        public string Read();
        public void Write(string message);
    }
}
