using Munchkin.Cards;
using Munchkin.Effects;
using Munchkin.Events;
using Munchkin.IO;
using Munchkin.Phases;
using Munchkin.Registries;
using Munchkin.Systems;

namespace Munchkin
{
    public class MunchkinGame
    {
        private readonly Random _random = new();
        private readonly GameRegistry _registry;
        private readonly GameServices _services;
        private readonly GameState _state;
        private readonly GameAPI _api;
        private readonly GameSettings _settings;

        public bool IsRunning => _state.IsRunning;
        internal MunchkinGame(GameSettings gameSettings, GameServices gameServices)
        {
            _services = gameServices;
            _settings = gameSettings;

            //_systems.TreasureDeck = CreateDeck(CardType.Treasure, 4, 76);
            //_systems.DoorDeck = CreateDeck(CardType.Door, 4, 92);
            //_systems.EffectDispatcher = new EffectDispatcher(_api);
            //_systems.TurnSystem = new TurnSystem(_state.Players);
            //_systems.CardSystem = new CardSystem(_systems.EffectDispatcher);

            //_registry.Cards.Register("test_card", new CardDefinition()
            //{
            //    Name = "Test Card",
            //    Description = "This is a test card.",
            //    Effects = new List<EffectDefinition>()
            //    {
            //        EffectFactory.Create<OnCardPlayed>((ctx, api, source) => Console.WriteLine(source.Definition.Name + " just played"))
            //    },
            //    CardType = CardType.Door
            //});

            //_registry.Cards.Register("test_card2", new CardDefinition()
            //{
            //    Name = "Test Card 2",
            //    Description = "This is a test card.2",
            //    Effects = new List<EffectDefinition>()
            //    {
            //        EffectFactory.Create<OnCardPlayed>((ctx, api, source) => Console.WriteLine(source.Definition.Name + " just played"))
            //    },
            //    CardType = CardType.Treasure
            //});
        }

        public MunchkinGame(GameSettings settings) : this(settings, MunchkinBootstrap.GetGameServices(settings)) { }

        private Deck CreateDeck(CardType type, int each, int max)
        {
            int current = 0;
            List<CardInstance> cards = new();

            foreach (var cardDef in _registry.Cards.GetAll().Where(x => x.CardType == type))
            {
                for (int i = 0; i < each; i++)
                {
                    if (current >= max) return new Deck(cards);
                    cards.Add(new CardInstance(cardDef));
                    current++;
                }
            }

            return new Deck(cards);
        }

        private void GiveStartingHands()
        {
            foreach (var player in _state.Players)
            {
                for (int i = 0; i < 1; i++)
                {
                    _systems.CardSystem.Draw(player, _systems.DoorDeck);
                    _systems.CardSystem.Draw(player, _systems.TreasureDeck);
                }
            }
        }

        public void Start()
        {
            _state.CurrentPhase = new TurnBegin(new TurnContext(_services.TurnSystem.CurrentPlayer), _services);
            _state.IsRunning = true;

            GiveStartingHands();
        }

        public void NextPhase()
        {
            _state.CurrentPhase = _state.CurrentPhase.Run();
        }
    }
}
