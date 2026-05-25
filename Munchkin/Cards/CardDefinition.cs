using Munchkin.Effects;
namespace Munchkin.Cards
{
    public class CardDefinition
    {
        public required string Name { get; set; }
        public string Description { get; set; } = "";
        public required List<EffectDefinition> Effects { get; set; } = new List<EffectDefinition>();
        public required CardType Type { get; set; }
        public CardData Data { get; } = new CardData();
        public List<CardTag> Tags { get; set; } = new List<CardTag>();

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

    public enum CardTag
    {
        Monster,
        Curse
    }
}
