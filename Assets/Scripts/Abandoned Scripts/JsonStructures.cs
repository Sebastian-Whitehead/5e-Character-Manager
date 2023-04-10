using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using OpenAI.Moderations;
using UnityEngine;
using DataStructures;
using Mono.CompilerServices.SymbolWriter;
using Unity.VisualScripting;

//TODO: SRD Package in program directory
//TODO: Go Through and reduce independent information that could just be included in the details / description field;

namespace JsonFormats
{
    public class BaseContentInfo
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Introduction { get; set; }
    }
    
    public class Spell : BaseContentInfo
    {
        public int Level { get; set; }
        public MagicSchool Type { get; set; }
        public CastTime CastingTime { get; set; }
        public Range SpellRange { get; set; }
        public AOE AreaOfEffect { get; set; }
        public SpellComponents Components { get; set; }
        public Duration SpellDuration { get; set; }
        public bool Ritual { get; set; }
        public PlayerClass[] AvailableForClasses { get; set; }
        
        public DiceRoll Damage { get; set; }
        public SavingThrow SpellSave { get; set; }
        public ScaleEffect[] HigherLevelEffect { get; set; }
    }
    
    public class Item : BaseContentInfo
    {
        public ItemSubType ItemType { get; set; }
        public ItemRarity Rarity { get; set; }
        public int Weight { get; set; }
        public Coin Value { get; set; }
        
        public int[] Damage { get; set; } // [nr. of dice, dice size, times x, plus y]
        public string DamageType { get; set; }

        public class Armour : Item
        {
            public new ArmourSubTypes ItemType;
            public ArmourAc ArmourClass;
            public int MinStrength;
            public bool StealthDisadvantage;
        }
        public class Weapon : Item
        {
            public new WeaponCategory ItemType;
            public Range WeaponRange;
            public Ability BaseAbility;
            public WeaponProperty[] Properties;
            public int AttackBonus;
            public Damage[] Dmg;
        }
        
        public class MagicalItem: Item
        {
            public new MagicItemType ItemType;
            public bool RequiresAttunement { get; set; }
            public string AttunementDetails { get; set; }
            public MagicCharages Charges { get; set; }
        }
        public class MagicalArmour: Armour
        {
            public bool RequiresAttunement { get; set; }
            public string AttunementDetails { get; set; }
            public MagicCharages Charges { get; set; }
        }
        public class MagicalWeapon : Weapon
        {
            public bool RequiresAttunement { get; set; }
            public string AttunementDetails { get; set; }
            public MagicCharages Charges { get; set; }
        }
    }
    
    public class Background : BaseContentInfo
    {
    }

    //TODO: WIP
    public class Feat : BaseContentInfo
    {
        public Prerequisite[] FeatPrerequisites { get; set; }
        public Modifier[] FeatModifiers { get; set; }
        public Spell[] GrantedSpells { get; set; }
    }
    
    public class Race : BaseContentInfo
    {
    }
    
    public class PlayerClass : BaseContentInfo
    {
    }
    
    public class PlayerSubclass : BaseContentInfo
    {
    }
    
    public class ClassFeature : BaseContentInfo
    {
    }
    
    public class RaceAbility : BaseContentInfo
    {
    }

    //TODO: Create a template ReadME file for all the different data structures
}
        



