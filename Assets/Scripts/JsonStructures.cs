using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using OpenAI.Moderations;
using UnityEngine;
using JsonFormats.DataStructures;

//TODO: SRD Package in program directory

namespace JsonFormats
{
    //TODO: Reconsider Weather Object arrays or structs should be used
    public class Spell
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        
        public int Level { get; set; }
        public MagicSchool Type { get; set; }
        public object[] CastTime { get; set; }
        public object[] Components { get; set; }
        public object[] Range { get; set; }
        public object[] Duration { get; set; }
        public bool Ritual { get; set; }
        public object[] Aoe { get; set; }
        public object[] WeaponAttackType { get; set; }
        
        public ScaleEffect[] HigherLevelEffect { get; set; }
        public PlayerClass[] AvailableForClasses { get; set; }
        
        public DiceRoll Damage { get; set; }
        public SavingThrow SpellSave { get; set; }
    }
    
    public class NonmagicalItem
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }

        public ItemType Type { get; set; }
        public ItemSubType ItemType { get; set; }
        public ArmourStatBlock ArmourStats { get; set; }
        public WeaponStatBlock WeaponStats { get; set; }
        
        public ItemRarity Rarity { get; set; }
        public int Weight { get; set; }
        public Coin Value { get; set; }
        
        public int[] Damage { get; set; } // [nr. of dice, dice size, times x, plus y]
        public string DamageType { get; set; }
    }
    public class MagicalItem: NonmagicalItem
    {
        public MagicItemType ItemType;
        public bool RequiresAttunement { get; set; }
        public string AttunementDetails { get; set; }
        public MagicCharages Charges { get; set; }
    }
    
    public class Background
    {
    }

    public class Feat
    {
    }

    //TODO: Create JSON structure for Races
    public class Race
    {
    }

    //TODO: Complete JSON structure for Character Classes
    public class PlayerClass
    {
    }

    //TODO: Create JSON structure for Character Sub Classes
    public class PlayerSubclass
    {

    }

    //TODO: Create JSON structure for Class Features
    public class ClassFeature
    {

    }

    //TODO: Create JSON structure for Race Abilities 
    public class RaceAbility
    {

    }

    //TODO: Create a template ReadME file for all the different data structures


    namespace DataStructures 
    {
        public enum MagicSchool // Schools of magic
        {
            Conjuration,
            Necromancy,
            Evocation,
            Abjuration,
            Transmutation,
            Divination,
            Enchantment,
            Illusion
        }

        public enum CastTimeFrame
        {
            Action,
            BonusAction,
            Hour,
            Minute,
            Reaction
        }
        public enum DurationUnit
        {
            Round,
            Minute,
            Hour,
            Day
        }
        public enum RangeType
        {
            Self,
            Touch,
            Ranged,
            Sight,
            Unlimited
        }
        public enum DurationType
        {
            Concentration,
            Instantaneous,
            Time,
            UntilDispelled,
            UntilDispelledOrTriggered
        }
        public enum AoeType
        {
            Cone,
            Cube,
            Cylinder,
            Line,
            Sphere,
            Square
        }
        public enum ScalingType // Type of scaling used for spell casting at higher levels [ScaleEffect]
        {
            CharacterLvl,
            SpellLvl,
            SpellScale
        }
        public struct ScaleEffect // Spell Effect At Higher Level
        {
            public ScalingType ScaleParam;
            public string Details;
            public int ScalingLvl;
            public int ScaleInterval;
            public object Value;

            public ScaleEffect(ScalingType scaleParam, int scalingLvl, int scaleInterval, object value, string details)
            {
                this.ScaleParam = scaleParam;
                this.Details = details;
                this.ScalingLvl = scalingLvl;
                this.ScaleInterval = scaleInterval;
                this.Value = value;
            }
        }

        public struct DiceRoll // Dice Roll Structure ~ 1d4+2
        {
            public int Count;
            public int Size;
            public int Plus;

            public DiceRoll(int diceCount, int diceType, int plus)
            {
                this.Count = diceCount;
                this.Size = diceType;
                this.Plus = plus;
            }
        }
        public struct Coin // Representation Of Value
        {
            public int Platinum;
            public int Gold;
            public int Silver;
            public int Copper;
            public int Electrum;

            public Coin(int p, int g, int s, int c, int e)
            {
                this.Platinum = p;
                this.Gold = g;
                this.Silver = s;
                this.Copper = c;
                this.Electrum = e;
            }
        }
        public enum AttackType
        {
            Melee,
            Ranged
        }

        public struct Damage
        {
            public DiceRoll Dice;
            public DamageType Type;
            
            public Damage(DiceRoll dice, DamageType type)
            {
                this.Dice = dice;
                this.Type = type;
            }
            
            public enum DamageType
            {
                Slashing,
                Piercing,
                Bludgeoning,
                Poison,
                Acid,
                Fire,
                Cold,
                Radiant,
                Necrotic,
                Lightning,
                Thunder,
                Force,
                Psychic
            }
        }
        public enum Ability
        {
            Con,
            Wis,
            Int,
            Char,
            Str,
            Dex
        }
        public struct SavingThrow
        {
            public Ability Type;
            public int Dc;

            public SavingThrow(Ability type, int dc)
            {
                this.Type = type;
                this.Dc = dc;
            }
        }
        
        public enum ItemRarity // Item Rarity
        {
            Unknown,
            Varies,
            Common,
            Uncommon,
            Rare,
            VeryRare,
            Legendary,
            Artifact
        }
        public enum ItemType // Item, Weapon or Armour
        {
            Item,
            Weapon,
            Armour
        }
        public enum ItemSubType // Types of items
        {
            Gemstone,
            AdventuringGear,
            Ammunition,
            Jewelry,
            Art,
            Tools,
            TradeGood,
            Food,
            GamingSet,
            Instrument,
            Focus,
        }
        
        public enum MagicItemType
        {
            WondrousItem,
            Rod,
            Scroll,
            Staff,
            Wand,
            Ring,
            Potion
        }
        public struct MagicCharages
        {
            public int Charges;
            public ChargeResetCondition ResetCondition;
            public string Details;

            public MagicCharages(int charges, ChargeResetCondition condition, string details)
            {
                this.Charges = charges;
                this.ResetCondition = condition;
                this.Details = details;
            }
            
            public enum ChargeResetCondition
            {
                ShortRest,
                LongRest,
                Dawn,
                None,
                Other,
            }
        }
        public struct ArmourStatBlock
        {
            public ArmourSubTypes Type;
            public ArmourAc ArmourClass;
            public int MinStrength;
            public bool StealthDisadvantage;

            public ArmourStatBlock(ArmourSubTypes type, ArmourAc ac, int min, bool stealthDis)
            {
                this.Type = type;
                this.ArmourClass = ac;
                this.MinStrength = min;
                this.StealthDisadvantage = stealthDis;
            }

            public struct ArmourAc
            {
                public int Base;
                public Ability Modifier;
                public int AbilityMax;

                public ArmourAc(int baseVal, Ability mod, int max)
                {
                    this.Base = baseVal;
                    this.Modifier = mod;
                    this.AbilityMax = max;
                }
            }
            
            public enum ArmourSubTypes
            {
                Light,
                Medium,
                Heavy
            }
        }
        public struct WeaponStatBlock
        {

            public WeaponCategory Category;
            public Ability BaseAbility;
            public int AttackBonus;
            public AttackType Type;
            public WeaponProperties[] Properties;
            public Damage[] Dmg;

            public WeaponStatBlock(WeaponCategory cat, AttackType type, WeaponProperties[] prop, Damage[] dmg,
                Ability baseAbility, int attackBonus)
            {
                this.Category = cat;
                this.Type = type;
                this.Properties = prop;
                this.Dmg = dmg;
                this.BaseAbility = baseAbility;
                this.AttackBonus = attackBonus;
            }
            
            public enum WeaponProperties
            {
                Light,
                Finesse,
                Thrown,
                TwoHanded,
                Versatile,
                Loading,
                Ammunition,
                Heavy,
                Reach,
                Special
            }
            public enum WeaponCategory
            {
                Martial,
                Simple
            }
        }
        
        public enum CreatureSize
        {
            Gargantuan, 
            Huge,
            Large,
            Medium,
            MediumOrSmall,
            Small,
            Tiny
        }
    }
}
        



