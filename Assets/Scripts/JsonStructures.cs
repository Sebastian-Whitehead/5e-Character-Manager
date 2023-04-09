using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using OpenAI.Moderations;
using UnityEngine;
using JsonFormats.DataStructures;
using Mono.CompilerServices.SymbolWriter;
using Unity.VisualScripting;

//TODO: SRD Package in program directory
//TODO: Go Through and reduce independent information that could just be included in the details / description field;

namespace JsonFormats
{
    public class Spell
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        
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
    
    public class Item
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        
        public ItemSubType ItemType { get; set; }
        public ItemRarity Rarity { get; set; }
        public int Weight { get; set; }
        public Coin Value { get; set; }
        
        public int[] Damage { get; set; } // [nr. of dice, dice size, times x, plus y]
        public string DamageType { get; set; }

        public class Armour : Item
        {
            public ArmourSubTypes ItemType;
            public ArmourAc ArmourClass;
            public int MinStrength;
            public bool StealthDisadvantage;
        }

        public class Weapon : Item
        {
            public WeaponCategory ItemType;
            public Range WeaponRange;
            public Ability BaseAbility;
            public WeaponProperty[] Properties;
            public int AttackBonus;
            public Damage[] Dmg;
        }
        
        public class MagicalItem: Item
        {
            public MagicItemType ItemType;
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


    public class Background
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Introduction { get; set; }
        
    }

    //TODO: WIP
    public class Feat
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }

        public Prerequisite[] FeatPrerequisites { get; set; }
        
    }
    
    public class Race
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
    }
    
    public class PlayerClass
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
    }
    
    public class PlayerSubclass
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
    }
    
    public class ClassFeature
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
    }
    
    public class RaceAbility
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
    }

    //TODO: Create a template ReadME file for all the different data structures


    namespace DataStructures 
    {
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
        public struct CastTime
        {
            public int Time;
            public CastingTimeFrame TimeFrame;
            public string ReactionTrigger;
            
            
            public CastTime(int time, CastingTimeFrame timeFrame, string reactionTrigger)
            {
                this.Time = time;
                this.TimeFrame = timeFrame;
                this.ReactionTrigger = reactionTrigger;
            }
            
            public enum CastingTimeFrame
            {
                Action,
                BonusAction,
                Hour,
                Minute,
                Reaction
            }
        }
        public struct SpellComponents
        {
            public bool Visual;
            public bool Semantic;
            public bool Material;
            public string RequiredMaterials;
            
            public SpellComponents(bool v, bool s, bool m, string requiredMaterials)
            {
                this.Visual = v;
                this.Semantic = s;
                this.Material = m;
                this.RequiredMaterials = requiredMaterials;
            }
        }
        public struct Range
        {   
            public RangeType Unit;
            public int MaxRange;
            public int MinRange;
            
            
            public enum RangeType
            {
                Self,
                Touch,
                Melee,
                Ranged,
                Sight,
                Unlimited
            }
        }
        public struct Duration
        {
            public DurationType Type;
            public int Value;
            public DurationUnit Unit;

            public Duration(DurationType type, int value, DurationUnit unit)
            {
                this.Type = type;
                this.Value = value;
                this.Unit = unit;
            }
            
            public enum DurationType
            {
                Concentration,
                Instantaneous,
                Time,
                UntilDispelled,
                UntilDispelledOrTriggered
            }
            public enum DurationUnit
            {
                Round,
                Minute,
                Hour,
                Day
            }
        }
        public struct AOE
        {
            public int Size;
            public AoeShape AreaShape;
            public bool Special;  // If more info is provided in the description
            
            public AOE(int size, AoeShape areaShape, bool special)
            {
                this.Size = size;
                this.AreaShape = areaShape;
                this.Special = special;
            }
            
            public enum AoeShape
            {
                Cone,
                Cube,
                Cylinder,
                Line,
                Sphere,
                Square
            }
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
            
            public enum ScalingType // Type of scaling used for spell casting at higher levels [ScaleEffect]
            {
                CharacterLvl,
                SpellLvl,
                SpellScale
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
        public enum WeaponProperty
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
            Martial_Melee,
            Martial_Ranged,
            Simple_Melee,
            Simple_Ranged
        }

        public struct Prerequisite
        {
            public PrerequisiteType Type;
            public object SubType;
            public int Value;

            public Prerequisite(PrerequisiteType type, object subType, int value)
            {
                this.Type = type;
                this.SubType = subType;
                this.Value = value;
            }
            
            public enum PrerequisiteType
            {
                AbilityScore,
                PlayerClass,
                CustomValue,
                Feat,
                Level,
                Proficiency
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
        



