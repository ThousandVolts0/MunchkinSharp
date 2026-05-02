using Munchkin.Effects;
namespace Munchkin
{
    public class Card
    {
        public required string Name { get; set; }
        public string Description { get; set; } = "";
        public required List<Effect> Effects { get; set; } = new List<Effect>();
        public required CardType CardType { get; set; }
    }

    public enum CardType
    {
        Door,
        Treasure
    }
}
