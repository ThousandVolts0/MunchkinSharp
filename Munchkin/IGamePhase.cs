using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin
{
    public interface IGamePhase
    {
        IGamePhase Run();
    }
}
