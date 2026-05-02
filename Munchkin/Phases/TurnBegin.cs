namespace Munchkin.Phases
{
    public class TurnBegin : IGamePhase
    {
        public TurnContext Context;
        public TurnBegin(TurnContext context)
        {
            Context = context;
        }
        public IGamePhase Run()
        {
            while (true)
            {
                Console.WriteLine("get card | play card");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "get card":
                        Context.ActivePlayer.Hand.Add(Context.GameContext.CardRegistry.Get("test_card"));
                        break;

                    //case "play card":
                    //    Console.WriteLine("which card do you want to play?");
                    //    string cardName = Console.ReadLine();
                    //    var card = Context.ActivePlayer.Hand.FirstOrDefault(c => c.Name == cardName);
                    //    if (card != null)
                    //    {
                    //        //Context.Player.PlayCard(card);
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("you don't have that card");
                    //    }
                    //    break;
                }
                break;
            }
            return new TurnEnd(Context);
        }
    }
}
