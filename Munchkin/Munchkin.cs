using Munchkin.Phases;
using Munchkin.Systems;
using System.Diagnostics.CodeAnalysis;

namespace Munchkin
{
    public class Munchkin
    {
        public IGamePhase CurrentPhase { get; private set; }

        public CardRegistry Cards { get; private set; } = new();

        private List<Player> _players = new();
        public IReadOnlyList<Player> Players => _players.AsReadOnly();

        public TurnSystem TurnSystem { get; private set; }
        public EventHub EventHub { get; private set; }
        public GameContext GameContext { get; private set; }

        public DeckBuilder DeckBuilder { get; private set; }
        public Deck TreasureDeck { get; private set; }
        public Deck DoorDeck { get; private set; }


        public Random Random { get; } = new Random();
        public bool IsRunning { get; private set; } = false;

        public IIOProvider IO { get; private set; } = new ConsoleIO();

        public Munchkin(GameSettings gameSettings)
        {
            IO = gameSettings.IOProvider;
            Init();
        }

        private void SetStartingPhase()
        {
            CurrentPhase = new TurnBegin(new TurnContext()
            {
                ActivePlayer = _players.FirstOrDefault() ?? throw new Exception("No players set"),
                GameContext = GameContext
            });
        }

        private void InitalizeDecks()
        {
            TreasureDeck = DeckBuilder.CreateDeck(CardType.Treasure);
            DoorDeck = DeckBuilder.CreateDeck(CardType.Door);
            DeckBuilder.FillDeck(TreasureDeck, 76);
            DeckBuilder.FillDeck(DoorDeck, 92);
        }

        private int PromptPlayerAmountSelect()
        {
            IO.Write("Select amount of players: ");
            while (true)
            {
                string input = IO.Read();

                if (input.Any() && int.TryParse(input, out int result))
                    return result;

                IO.Write("Invalid input, try again: ");
            }
        }


        private List<Player> PromptPlayerCreation(int playerAmount)
        {
            List<Player> players = new();
            int playersLeft = playerAmount;
            while (playersLeft > 0)
            {
                IO.Write($"Enter name for player {playerAmount - playersLeft + 1}: "); 
                string playerName = IO.Read();
                players.Add(new Player() { Name = playerName });
                playersLeft--;
            }

            return players;
        }

        private void Init()
        {
            GameContext = new GameContext();
            GameContext.CardRegistry = Cards;
            GameContext.Random = Random;

            EventHub = new EventHub(GameContext);
            TurnSystem = new TurnSystem(Players);
            DeckBuilder = new DeckBuilder(Cards);

            GameContext.TurnSystem = TurnSystem;

            InitalizeDecks();
        }

        public void Start()
        {
            IsRunning = true;

            int playerAmount = PromptPlayerAmountSelect();
            List<Player> players = PromptPlayerCreation(playerAmount);

            _players.Clear();
            _players.AddRange(players);
            SetStartingPhase();

            GameLoop();
        }

        private void GameLoop()
        {
            while (IsRunning)
            {
                NextState();
            }
        }

        private void NextState()
        {
            CurrentPhase = CurrentPhase.Run();
        }
    }
}
