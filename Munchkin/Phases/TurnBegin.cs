using Munchkin.Cards;

namespace Munchkin.Phases
{
    public class TurnBegin : IGamePhase
    {
        public TurnContext TurnContext; 
        public GameServices GameSystems;
        public TurnBegin(TurnContext turnContext, GameServices gameContext)
        {
            TurnContext = turnContext;
            GameSystems = gameContext;
        }

        public IGamePhase Run()
        {
            Player player = TurnContext.ActivePlayer;
            while (true)
            {
                Console.WriteLine(player.Name);
                Console.WriteLine("get card | show cards | play card | end turn");

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "get card":
                        //GameContext.CardSystem.GiveCard(player, GameAPI.GetCard("test_card"));
                        GameSystems.CardSystem.Play(player.Hand[0], player);
                        break;
                    case "show cards":
                        foreach (CardInstance card in player.Hand)
                        {
                            Console.WriteLine(card.Definition.Name);
                        }
                        break;
                    case "play card":
                        GameSystems.CardSystem.Play(player.Hand[0],player);
                        break;
                    //case "end turn":
                        //return new TurnEnd(new TurnContext(GameAPI.TurnSystem.GetActivePlayer()), GameAPI);
                }
                break;
            }
            TurnContext context = new(player);
            return new TurnEnd(context, GameSystems);
        }
    }
}
