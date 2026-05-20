using Munchkin.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin
{
    public class GameSettings
    {
        public required IIOProvider IOProvider { get; set; }
        public required List<string> PlayerNames { get; set; }
    }
}
