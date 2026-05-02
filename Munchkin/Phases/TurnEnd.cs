using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Phases
{
    public class TurnEnd : IGamePhase
    {
        public TurnContext Context;
        public TurnEnd(TurnContext context)
        {
            Context = context;
        }
        public IGamePhase Run()
        {
            TurnContext context = new TurnContext()
            {
                ActivePlayer = Context.GameContext.TurnSystem.AdvanceTurn(),
                GameContext = Context.GameContext
            };

            return new TurnBegin(context);
        }
    }
}
