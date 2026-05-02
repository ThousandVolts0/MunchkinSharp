using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin
{
    public class ConsoleIO : IIOProvider
    {
        public string Read()
        {
            return Console.ReadLine() ?? "";
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
