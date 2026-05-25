using Munchkin.Cards;
using Munchkin.Events;
using Munchkin.IO;
using Munchkin.Services;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Munchkin.Phases
{
    public class CombatBegin : IGamePhase
    {
        private CombatContext _combatContext;
        private GameServices _services;
        private GameSettings _settings;
        public CombatBegin(CombatContext combatContext, GameServices services, GameSettings settings)
        {
            _combatContext = combatContext;
            _services = services;
            _settings = settings;
        }

        public IGamePhase Run()
        {
            EffectDispatchService effectService = _services.Get<EffectDispatchService>();
            CombatService combatService = _services.Get<CombatService>();
            IIOProvider io = _settings.IOProvider;
            Player player = _combatContext.ActivePlayer;
            CardInstance card = _combatContext.Monster;

            io.Clear();
            io.Write($"{player.Name} encounters {card.Definition.Name}!");

            effectService.Invoke(new OnCombatStart { Player = player, Monster = card });
            bool win = combatService.EvaluateCombat(player, card);

            IGameEvent combatResultEvent = win ? new OnCombatWin { Player = player, Monster = card } : new OnCombatLose { Player = player, Monster = card };
            effectService.Invoke(combatResultEvent);
            io.Write(win ? $"{player.Name} won the combat!" : $"{player.Name} lost the combat!");
            io.Write("Press any key to continue...");
            io.Read();

            return new TurnEnd(new TurnContext(player), _services, _settings);
        }
    }
}
