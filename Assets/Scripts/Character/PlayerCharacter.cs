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

        public Dictionary<string, AbilityScore> AbilityScores;

        // Ability Scores:
        /*
        public int str; 
        public int dex;
        public int con;
        public int inte;
        public int wis;
        public int cha;
        */
        
        // Saving Throw:
        public SavingThrow SvStr;
        public SavingThrow SvDex;
        public SavingThrow SvCon;
        public SavingThrow SvInte;
        public SavingThrow SvWis;
        public SavingThrow SvCha;
    
        // Death Saves:
        public bool conscious = true;
        public bool alive = true;
        [FormerlySerializedAs("DS_sucess")] public int dsSucess = 0;
        [FormerlySerializedAs("DS_fail")] public int dsFail = 0;
        [FormerlySerializedAs("DS_stable")] public bool dsStable = true;
        
        // Skills:
        public Skill Acrobatics;
        public Skill AnimalHandling;
        public Skill Arcana;
        public Skill Athletics;
        public Skill Deception;
        public Skill History;
        public Skill Insight;
        public Skill Intimidation;
        public Skill Investigation;
        public Skill Medicine;
        public Skill Nature;
        public Skill Perception;
        public Skill Performance;
        public Skill Persuasion;
        public Skill Religion;
        public Skill SlightOfHand;
        public Skill Stealth;
        public Skill Survival;

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
            AbilityScores.Add("str", new AbilityScore(16, CalculateBonus(16)));
            AbilityScores.Add("dex", new AbilityScore(17, CalculateBonus(17)));
            AbilityScores.Add("con", new AbilityScore(16, CalculateBonus(16)));
            AbilityScores.Add("int", new AbilityScore(14, CalculateBonus(14)));
            AbilityScores.Add("wis", new AbilityScore(9, CalculateBonus(9)));
            AbilityScores.Add("cha", new AbilityScore(6, CalculateBonus(6)));

            // Defning saving throws
            SvStr = new SavingThrow(true, CalculateBonus(AbilityScores["str"].Score, true));
            SvDex = new SavingThrow(false, CalculateBonus(AbilityScores["dex"].Score, false));
            SvCon = new SavingThrow(true, CalculateBonus(AbilityScores["con"].Score, true));
            SvInte = new SavingThrow(false, CalculateBonus(AbilityScores["int"].Score, true));
            SvWis = new SavingThrow(false, CalculateBonus(AbilityScores["wis"].Score, false)); 
            SvCha = new SavingThrow(false, CalculateBonus(AbilityScores["cha"].Score, false));
            
            // Defining current number of success and fail
            dsSucess = 0;
            dsFail = 0;
            
            // Defining hitdice
            HitDice = new HitDie(1, 6, 4, 4); // 1d6 total: 4/4
        
            // Defining and calculating abilities
            Acrobatics = new Skill(false, CalculateBonus(AbilityScores["dex"].Score, false));
            AnimalHandling = new Skill(false, CalculateBonus(AbilityScores["wis"].Score, false));
            Arcana = new Skill(false, CalculateBonus(AbilityScores["int"].Score, false));
            Athletics = new Skill(false, CalculateBonus(AbilityScores["str"].Score, true));
            Deception = new Skill(false, CalculateBonus(AbilityScores["cha"].Score, false));
            History = new Skill(false, CalculateBonus(AbilityScores["int"].Score, false));
            Insight = new Skill(true, CalculateBonus(AbilityScores["wis"].Score, true));
            Intimidation = new Skill(true, CalculateBonus(AbilityScores["cha"].Score, true));
            Investigation = new Skill(false, CalculateBonus(AbilityScores["int"].Score, false));
            Medicine = new Skill(false, CalculateBonus(AbilityScores["wis"].Score, false));
            Nature = new Skill(false, CalculateBonus(AbilityScores["int"].Score, false));
            Perception = new Skill(true, CalculateBonus(AbilityScores["wis"].Score, true));
            Performance = new Skill(false, CalculateBonus(AbilityScores["cha"].Score, false));
            Persuasion = new Skill(false, CalculateBonus(AbilityScores["cha"].Score, false));
            Religion = new Skill(false, CalculateBonus(AbilityScores["int"].Score, false));
            SlightOfHand = new Skill(false, CalculateBonus(AbilityScores["dex"].Score, false));
            Stealth = new Skill(false, CalculateBonus(AbilityScores["dex"].Score, false ));
            Survival = new Skill(true, CalculateBonus(AbilityScores["wis"].Score, true));

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
        
        // Function to calculate bonus from score
        public int CalculateBonus(float score)
        {
            score -= 10;
            int bonus = (int)Mathf.Floor(score / 2);
            return bonus;
        }
        
        //Function to calculate bonus from score w. proficiency
        public int CalculateBonus(float score, bool prof)
        {
            int bonus = CalculateBonus(score);
            if (prof) bonus += profBonus; // If proficient add bonus
            return bonus;
        }
        
    }
}