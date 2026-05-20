using Munchkin.Effects;
namespace Munchkin.Cards
{
    public class CardDefinition
    {
        public required string Name { get; set; }
        public string Description { get; set; } = "";
        public required List<EffectDefinition> Effects { get; set; } = new List<EffectDefinition>();
        public required CardType CardType { get; set; }

        public CardInstance CreateInstance()
        {
            return new CardInstance(this);
        }
    }

    public enum CardType
    {
        Door,
        Treasure
    }
}
