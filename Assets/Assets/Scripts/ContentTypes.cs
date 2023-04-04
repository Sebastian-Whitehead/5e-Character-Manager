using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*TODO:
 - Background
 - Racial Ability
 - Player Race
 - Player Class
 - Player Subclass
    */

namespace ContentTypes
{
    /* Key:
     ~          example
     //         or
     ...        or similar
     (if! x)    What to set a variable to if not applicable if not specified then dont define
    */ 
    
    public class Spell
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Description { get; set; } 
        public string HigherLvl { get; set; }   // effect change at higher level
        
        public int Lvl { get; set; }            
        public string School { get; set; }      
        public string[] Classes { get; set; }   
        public bool[] Components { get; set; }  //V-isual , S-ematic, M-material
        public string[] Materials { get; set; } //Required materials otherwise null
    
        public int Range { get; set; }          // ft.
        public string Target { get; set; }      
        public string CastTime { get; set; }    
        public string Duration { get; set; }    // Minutes
        public bool Concentration { get; set; }
        
        //WIP <
        public string Damage { get; set; }      // "1d4"
        public string DamageType { get; set; }  // "Frost"
        // > may not be useful
    }

    public class Item
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        
        public string Type { get; set; }    //~ "Adventuring Gear" // "Armour", Weapon ...
        public string Subtype { get; set; } // ~"Wrist" // "Neck" ...
        public bool Wondrous { get; set; } 
        public string Rarity { get; set; }  // ~"common" // "uncommon" ...
        public float Weight { get; set; }   // lbs. (if! 0)
        public bool RequiresAttunement { get; set; }
        
        public string Damage { get; set; }
        public string DamageType { get; set; }
    }

    public class Background
    {
        
    }

    public class Feat
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        
        // All Requirements for the Feat
        public bool Prerequisites { get; set; }     // Are there required prerequisites
        public bool ReqSpellCasting { get; set; }
        public string ReqClassFeature { get; set; }
        public string ReqRace { get; set; }
        public string ReqSubrace { get; set; }
        public string[] ReqAbilityScore { get; set; }   // {ability, Minimum score, ...}     
        public string ReqFeat { get; set; }             
        public string ReqProficiency { get; set; }
        public string ReqOther { get; set; }
    }

    public class ClassAbility
    {
        
    }
    
    public class RacialAbility
    {
        
    }

    public class PlayerRace
    {
        
    }

    public class PlayerClass
    {
        
    }
    
    public class PlayerSubclass{
    
    }
}

