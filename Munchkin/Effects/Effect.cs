using Munchkin.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Effects
{
    public class Effect
    {
        public required Type EventType { get; set; }
        public required Action<IGameEvent, GameContext> Action { get; set; }
        public Func<IGameEvent, GameContext, bool>? Condition { get; set; }
    }
}
