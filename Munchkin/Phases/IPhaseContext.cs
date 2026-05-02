using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Phases
{
    public interface IPhaseContext
    {
        GameContext GameContext { get; }
    }
}
