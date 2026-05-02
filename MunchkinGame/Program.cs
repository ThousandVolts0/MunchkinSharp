using Munchkin;
using Munchkin.Systems;
using Munchkin.Events;
using Munchkin.Effects;

namespace MunchkinGame{
    internal class Program
    {
        static void Main(string[] args)
        {
            Munchkin.Munchkin game = new Munchkin.Munchkin(new GameSettings() { IOProvider = new ConsoleIO() });

            Card card = new Card()
            {
                Name = "Test Card",
                Description = "This is a test card.",
                Effects = new List<Effect>()
                {
                    EffectFactory.Create<OnTurnBegin>("TestEffect", (ev, ctx) => Console.WriteLine(ev))
                },
                CardType = CardType.Door
            };
            game.Cards.Register("test_card", card);
            game.Start();
        }
    }
}
