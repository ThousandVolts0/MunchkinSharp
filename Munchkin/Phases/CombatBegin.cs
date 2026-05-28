using Munchkin.Cards;
using Munchkin.Cards.Components;
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
            IIOProvider io = _settings.IOProvider;
            Player player = _combatContext.ActivePlayer;
            CardInstance card = _combatContext.Monster;

            io.Clear();
            io.Write($"{player.Name} encounters {card.Definition.Name}!");

            OnCombatStart combatStartEvent = new OnCombatStart(player, card);
            effectService.Invoke(combatStartEvent);

            int bonus = combatStartEvent.Bonus.GetTotal();
            int monsterLevel = card.Definition.GetComponent<MonsterComponent>().Level;

            io.Write($"Player Level: {player.Level}");
            io.Write($"Monster Level: {monsterLevel}");
            io.Write($"Bonus: {bonus}");

            bool win = player.Level + bonus >= monsterLevel;

            IGameEvent combatResultEvent = win ? new OnCombatWin { Player = player, Monster = card } : new OnCombatLose { Player = player, Monster = card };
            effectService.Invoke(combatResultEvent);

            io.Write(win ? $"{player.Name} won the combat!" : $"{player.Name} lost the combat!");
            io.Write("Press any key to continue...");
            io.Read();

            return new TurnEnd(new TurnContext(player), _services, _settings);
        }
    }
}
