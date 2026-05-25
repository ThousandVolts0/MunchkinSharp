using Munchkin.Cards;
using Munchkin.Phases;
using Munchkin.Registries;
using Munchkin.Services;

namespace Munchkin
{
    public class MunchkinGame
    {
        private readonly Random _random = new();
        private readonly GameRegistry _registry = new();
        private readonly GameServices _services;
        private readonly GameState _state;
        private readonly GameSettings _settings;

        public bool IsRunning => _state.IsRunning;
        internal MunchkinGame(GameSettings gameSettings, GameServices gameServices)
        {
            _services = gameServices;
            _settings = gameSettings;
            _state = new GameState();
            _state.Players = gameSettings.Players;

            MunchkinDefaultCards.Load(_registry);
            DeckService deckService = _services.Get<DeckService>();
            //deckService.Create(CardType.Treasure);
            deckService.Create(CardType.Door);
            var doorCards = _registry.Cards.GetAll().Where(c => c.Type == CardType.Door).ToList();
            deckService.Fill(CardType.Door, doorCards, 20, 100);
        }

        public MunchkinGame(GameSettings settings) : this(settings, MunchkinBootstrap.CreateGameServices(settings)) { }

        private void GiveStartingHands()
        {
            CardInteractionService cardService = _services.Get<CardInteractionService>();
            DeckService deckService = _services.Get<DeckService>(); 
            foreach (var player in _state.Players)
            {
                for (int i = 0; i < 4; i++)
                {
                    cardService.AddCardToHand(deckService.Draw(CardType.Door), player);
                    //cardService.AddToHand(deckService.Draw(CardType.Treasure), player);
                }
            }
        }

        public void Start()
        {
            _state.CurrentPhase = new TurnBegin(new TurnContext(_services.Get<TurnService>().CurrentPlayer), _services, _settings);
            _state.IsRunning = true;

            GiveStartingHands();
        }

        public void Update()
        {
            _state.CurrentPhase = _state.CurrentPhase.Run();
        }
    }
}
