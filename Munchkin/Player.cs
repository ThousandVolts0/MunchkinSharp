using System.Net.Security;

namespace Munchkin
{
    public class Player
    {
        public string Name { get; set; } = "";
        public int Health { get; set; } = 100;
        public int Level { get; set; } = 0;
        public Race Race { get; set; } = Race.Human;

        public Dictionary<SlotType, Card> Slots { get; set; } = new();

        public List<Card> Hand { get; set; } = new();
        public List<Card> Played { get; set; } = new();

        public void AddCard(Card card) => Hand.Add(card);
        public void RemoveCard(Card card) => Hand.Remove(card);
    }

    public enum SlotType
    {
        Hand,
        Chest,
        Feet,
        LeftHand,
        RightHand
    }

    public enum Race
    {
        Human,
        Elf,
        Dwarf,
        Halfling
    }

    public enum Occupation
    {
        Warrior,
        Wizard,
        Thief,
        Cleric
    }
}
