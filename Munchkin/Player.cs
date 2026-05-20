using Munchkin.Cards;
using System.Net.Security;

namespace Munchkin
{
    public class Player
    {
        public string Name { get; set; } = "";
        public int Health { get; set; } = 100;
        public int Level { get; set; } = 0;
        public Race Race { get; set; } = Race.Human;

        public Dictionary<SlotType, CardInstance> Slots { get; } = new();
        public List<CardInstance> Hand { get; }  = new();
        public List<CardInstance> Played { get; } = new();
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
