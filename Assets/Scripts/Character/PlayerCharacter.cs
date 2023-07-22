using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character
{
    public class PlayerCharacter : MonoBehaviour
    {
        public string experiencePoints;
    
        public string characterName;
        public int level;
        public string[] characterClasses;
        public string characterRace;
    
        public int health;
        public int tempHealth;
        public int maxHealth;
        public HitDie HitDice;
    
        public int profBonus;
        public int walkingSpeed;
        public int initiative;
        [FormerlySerializedAs("AC")] public int ac;

        public string[] defenses;
        public string[] immunities;
        public string[] activeConditions;

        // Ability Scores:
        public Dictionary<string, AbilityScore> AbilityScores;

        // Skills:
        public Dictionary<string, Skill> SkillList;
        
        // Saving Throw:
        public Dictionary<string, SavingThrow> SavingThrows;

        // Death Saves:
        public bool conscious = true;
        public bool alive = true;
        [FormerlySerializedAs("DS_sucess")] public int dsSucess = 0;
        [FormerlySerializedAs("DS_fail")] public int dsFail = 0;
        [FormerlySerializedAs("DS_stable")] public bool dsStable = true;
        
        // Senses:
        public int pasPerception;
        public int pasInvestigation;
        public int pasInsight;
        public int darkVision;

        // Profs & Languages:
        public string[] armor;
        public string[] weapons;
        public string[] tools;
        public string[] languages;

        // Description:
        public string background;
    
        public string alignment;
        public string faith;
        public string gender;
        public string size;
    
        public string eyes;
        public string height;
        public string weight;
        public string hair;
        public string skin;
        public string age;
    
        public string personalityTraits;
        public string ideals;
        public string bonds;
        public string flaws;

        public string appearance;
    
        //Inventory;
        public int carryCapacity;
        public float carryWeight;

        public Currency Money;
        public Item[] Equipment;
    
        public int attunedCount;
        public int attunedMax;
    
        //Notes:
        public string organizations;
        public string allies;
        public string enemies;
        public string backstory;
        public string generalNotes;

        //Spells & attacks:
        public Spell[] SpellSlots = new Spell[10];
        public int[] maxKnown;
        [FormerlySerializedAs("spellSaveDC")] public int spellSaveDc;
        public int modifier;
        public int spellAttackModifier;
        public int sorceryPoints = 0;

        public PlayerCharacter(Dictionary<string, AbilityScore> abilityScores)
        {
            this.AbilityScores = abilityScores;
        }

        //TODO: Features & Traits
        //TODO: Actions
    
        
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
    
        public void LoadTestCharacter()
        {
            // Basic Character information.
            characterName = "Jeff";
            level = 2;
            characterClasses = new string[]{"Ranger", "Wizard"};
            characterRace = "elf";

            health = 10;
            tempHealth = 0;
            maxHealth = 15;
        
            profBonus = 2;
            walkingSpeed = 35;
            initiative = 3;
            ac = 16;
            
            // Defining base ability scores
            // Standard ORDER: str, dex, con, int, wis, cha
            AbilityScores.Add("str", new AbilityScore(16, CalculateBonus(16)));
            AbilityScores.Add("dex", new AbilityScore(17, CalculateBonus(17)));
            AbilityScores.Add("con", new AbilityScore(16, CalculateBonus(16)));
            AbilityScores.Add("int", new AbilityScore(14, CalculateBonus(14)));
            AbilityScores.Add("wis", new AbilityScore(9, CalculateBonus(9)));
            AbilityScores.Add("cha", new AbilityScore(6, CalculateBonus(6)));

            // Defning saving throws
            SavingThrows.Add("str", new SavingThrow(true, CalculateSkillBonus(AbilityScores["str"].Score, ProfLvl.Proficient)));
            SavingThrows.Add("dex", new SavingThrow(false, CalculateSkillBonus(AbilityScores["dex"].Score, ProfLvl.None)));
            SavingThrows.Add("con", new SavingThrow(true, CalculateSkillBonus(AbilityScores["con"].Score, ProfLvl.Proficient)));
            SavingThrows.Add("int", new SavingThrow(false, CalculateSkillBonus(AbilityScores["int"].Score, ProfLvl.None)));
            SavingThrows.Add("wis", new SavingThrow(false, CalculateSkillBonus(AbilityScores["wis"].Score, ProfLvl.None))); 
            SavingThrows.Add("cha", new SavingThrow(false, CalculateSkillBonus(AbilityScores["cha"].Score, ProfLvl.None)));
            
            // Defining current number of success and fail
            dsSucess = 0;
            dsFail = 0;
            
            // Defining hitdice
            HitDice = new HitDie(1, 6, 4, 4); // 1d6 total: 4/4
        
            // Defining and calculating abilities
            SkillList.Add("Acrobatics", new Skill(ProfLvl.None, CalculateSkillBonus(AbilityScores["dex"].Score, ProfLvl.None), "dex"));
            SkillList.Add("AnimalHandling", new Skill(ProfLvl.None, CalculateSkillBonus(AbilityScores["wis"].Score, ProfLvl.None), "wis"));
            SkillList.Add("Arcana", new Skill(ProfLvl.None, CalculateSkillBonus(AbilityScores["int"].Score, ProfLvl.None),"int"));
            SkillList.Add("Athletics", new Skill(ProfLvl.Proficient, CalculateSkillBonus(AbilityScores["str"].Score, ProfLvl.Proficient), "str"));
            SkillList.Add("Deception", new Skill(ProfLvl.None, CalculateSkillBonus(AbilityScores["cha"].Score, ProfLvl.None), "cha"));
            SkillList.Add("History", new Skill(ProfLvl.None, CalculateSkillBonus(AbilityScores["int"].Score, ProfLvl.None), "int"));
            SkillList.Add("Insight", new Skill(ProfLvl.Proficient, CalculateSkillBonus(AbilityScores["wis"].Score, ProfLvl.Proficient), "wis"));
            SkillList.Add("Intimidation", new Skill(ProfLvl.Proficient, CalculateSkillBonus(AbilityScores["cha"].Score, ProfLvl.Proficient), "cha"));
            SkillList.Add("Investigation", new Skill(ProfLvl.None, CalculateSkillBonus(AbilityScores["int"].Score, ProfLvl.None), "int"));
            SkillList.Add("Medicine", new Skill(ProfLvl.None, CalculateSkillBonus(AbilityScores["wis"].Score, ProfLvl.None), "wis"));
            SkillList.Add("Nature", new Skill(ProfLvl.None, CalculateSkillBonus(AbilityScores["int"].Score, ProfLvl.None), "int"));
            SkillList.Add("Perception", new Skill(ProfLvl.Proficient, CalculateSkillBonus(AbilityScores["wis"].Score, ProfLvl.Proficient), "wis"));
            SkillList.Add("Performance", new Skill(ProfLvl.None, CalculateSkillBonus(AbilityScores["cha"].Score, ProfLvl.None), "cha"));
            SkillList.Add("Persuasion", new Skill(ProfLvl.None, CalculateSkillBonus(AbilityScores["cha"].Score, ProfLvl.None), "cha"));
            SkillList.Add("Religion", new Skill(ProfLvl.None, CalculateSkillBonus(AbilityScores["int"].Score, ProfLvl.None), "int"));
            SkillList.Add("SlightOfHand", new Skill(ProfLvl.None, CalculateSkillBonus(AbilityScores["dex"].Score, ProfLvl.None), "dex"));
            SkillList.Add("Stealth", new Skill(ProfLvl.None, CalculateSkillBonus(AbilityScores["dex"].Score, ProfLvl.None ), "dex"));
            SkillList.Add("Survival", new Skill(ProfLvl.Expert, CalculateSkillBonus(AbilityScores["wis"].Score, ProfLvl.Expert), "wis"));

            pasPerception = 13;
            pasInvestigation = 12;
            pasInvestigation = 13;
            darkVision = 60;

            
            //Defining Spell slots and remain spells
            SpellSlots[0] = new Spell(Mathf.Infinity, Mathf.Infinity); //Cantrips
            SpellSlots[1] = new Spell(4, 4);    // Level 1
            SpellSlots[2] = new Spell(3, 3);    // Level 2
            SpellSlots[3] = new Spell(false);    // Level 3
            SpellSlots[4] = new Spell(false);    // Level 4
            SpellSlots[5] = new Spell(false);    // ...
            SpellSlots[6] = new Spell(false);   
            SpellSlots[7] = new Spell(false);    
            SpellSlots[8] = new Spell(false);
            SpellSlots[9] = new Spell(false);
        }
        
        
        // ----------------------------------Calculations---------------------------------------- //
        
        
        // TODO: CHECK THAT THIS WORKS WITH EXPERTISE CALCULATIONS
        // Function to calculate bonus from score
        public int CalculateBonus(float score)
        {
            score -= 10;
            int bonus = (int)Mathf.Floor(score / 2);
            return bonus;
        }
        
        //Function to calculate bonus from score w. proficiency
        public int CalculateSkillBonus(float score, ProfLvl prof )
        {
            int bonus = CalculateBonus(score);
            switch (prof)
            {
                case ProfLvl.Expert:
                    bonus += (profBonus * 2);
                    break;
                case ProfLvl.Proficient:
                    bonus += profBonus; // If proficient add bonus
                    break;
            }
            return bonus;
        }
        
    }
}