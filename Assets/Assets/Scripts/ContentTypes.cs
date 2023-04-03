using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ContentTypes
{
    public class Spell
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public int Lvl { get; set; }
        public string School { get; set; }
        public string[] Classes { get; set; }
    
        public bool[] Components { get; set; }
        public string[] Materials { get; set; }
    
        public int Range { get; set; }
        public string Target { get; set; }
        public string Damage { get; set; }
        public string DamageType { get; set; }
        public string CastTime { get; set; }
        public string Duration { get; set; }
        public bool Concentration { get; set; }
    
        public string Description { get; set; }
        public string HigherLvl { get; set; }
    
    }

    public class Item
    {
        
    }

    public class Weapon
    {
        
    }

    public class Feat
    {
        
    }

    public class RacialAbility
    {
        
    }
}

