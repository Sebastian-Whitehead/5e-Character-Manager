using NUnit.Framework;

namespace DataStructures
{
    public struct Skill
    {
        public Skill(bool prof, int bonus)
        {
            Prof = prof;
            Bonus = bonus;
        }
        
        public bool Prof { get; }
        public int Bonus { get; }
    }
    
    public struct SavingThrow
    {
        public SavingThrow(bool prof, int bonus)
        {
            Prof = prof;
            Bonus = bonus;
        }

        public bool Prof;
        public int Bonus;
    }

    public struct Currency
    {

        public Currency(int plat, int elec, int gold, int silver, int copper)
        {
            Platinum = plat;
            Electrum = elec;
            Gold = gold;
            Silver = silver;
            Copper = copper;
        }

        public int Platinum;
        public int Electrum;
        public int Gold;
        public int Silver;
        public int Copper;
    }

    public struct Item
    {
        public Item(string name, float weight, int quantity, float cost, string notes)
        {
            Name = name;
            Weight = weight;
            Quantity = quantity;
            Cost = cost;
            Notes = notes;
        }

        public string Name;
        public float Weight;
        public int Quantity;
        public float Cost;
        public string Notes;
    }
    
    //TODO: Spell Struct
}
