using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Munchkin.Phases
{
    public class TurnEnd : IGamePhase
    {
        public TurnContext TurnContext;
        public GameSystems GameContext;
        public TurnEnd(TurnContext turnContext, GameSystems gameContext)
        {
            TurnContext = turnContext;
            GameContext = gameContext;
        }

        public IGamePhase Run()
        {
            GameContext.TurnSystem.AdvanceTurn();
            return new TurnBegin(new TurnContext(TurnContext.ActivePlayer), GameContext);
        }
    }
}
