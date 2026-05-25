using Munchkin.Cards.Components;
using Munchkin.Effects;
namespace Munchkin.Cards
{
    public class CardDefinition
    {
        public required string Name { get; set; }
        public string Description { get; set; } = "";
        public required List<EffectDefinition> Effects { get; set; } = new List<EffectDefinition>();
        public required CardType Type { get; set; }

        public List<ICardComponent> Components { get; set; } = new();

        public T GetComponent<T>() where T : ICardComponent
        {
            return Components.OfType<T>().FirstOrDefault() ?? throw new InvalidOperationException($"Card does not contain a component of type {typeof(T).Name}");
        }

        public bool HasComponent<T>() where T : ICardComponent
        {
            return Components.OfType<T>().FirstOrDefault() != null; 
        }

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
