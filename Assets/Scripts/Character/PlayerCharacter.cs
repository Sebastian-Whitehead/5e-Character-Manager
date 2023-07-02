using System;
using UnityEngine;

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
        public int AC;

        public string[] defenses;
        public string[] immunities;
        public string[] activeConditions;

    
        // Ability Scores:
        public int str; 
        public int dex;
        public int con;
        public int inte;
        public int wis;
        public int cha;

        // Saving Throw:
        public SavingThrow SV_str;
        public SavingThrow SV_dex;
        public SavingThrow SV_con;
        public SavingThrow SV_inte;
        public SavingThrow SV_wis;
        public SavingThrow SV_cha;
    
        // Death Saves:
        public bool conscious = true;
        public bool alive = true;
        public int DS_sucess = 0;
        public int DS_fail = 0;
        public bool DS_stable = true;
        
        // Skills:
        public Skill acrobatics;
        public Skill animalHandling;
        public Skill arcana;
        public Skill athletics;
        public Skill deception;
        public Skill history;
        public Skill insight;
        public Skill intimidation;
        public Skill investigation;
        public Skill medicine;
        public Skill nature;
        public Skill perception;
        public Skill performance;
        public Skill persuasion;
        public Skill religion;
        public Skill slightOfHand;
        public Skill stealth;
        public Skill survival;

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

        public Currency money;
        public Item[] equipment;
    
        public int attunedCount;
        public int attunedMax;
    
        //Notes:
        public string organizations;
        public string allies;
        public string enemies;
        public string backstory;
        public string generalNotes;

        //Spells & attacks:
        public Spell[] spellSlots = new Spell[10];
        public int[] maxKnown;
        public int spellSaveDC;
        public int modifier;
        public int spellAttackModifier;
       

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
            AC = 16;
            
            // Defining base ability scores
            str = 16;
            dex = 17;
            con = 16;
            inte = 14;
            wis = 13;
            cha = 12;
            
            // Defning saving throws
            SV_str = new SavingThrow(true, CalculateBonus(str) + profBonus);
            SV_dex = new SavingThrow(false, CalculateBonus(dex));
            SV_con = new SavingThrow(true, CalculateBonus(con) + profBonus);
            SV_inte = new SavingThrow(false, CalculateBonus(inte));
            SV_wis = new SavingThrow(false, CalculateBonus(wis)); 
            SV_cha = new SavingThrow(false, CalculateBonus(cha));
            
            // Defining current number of success and fail
            DS_sucess = 0;
            DS_fail = 0;
            
            // Defining hitdice
            HitDice = new HitDie(1, 6, 4, 4); // 1d6 total: 4/4
        
            // Defining and calculating abilities
            acrobatics = new Skill(false, CalculateBonus(dex));
            animalHandling = new Skill(false, CalculateBonus(wis));
            arcana = new Skill(false, CalculateBonus(inte));
            athletics = new Skill(false, CalculateBonus(str, true));
            deception = new Skill(false, CalculateBonus(cha));
            history = new Skill(false, CalculateBonus(inte));
            insight = new Skill(true, CalculateBonus(wis, true));
            intimidation = new Skill(true, CalculateBonus(cha, true));
            investigation = new Skill(false, CalculateBonus(inte));
            medicine = new Skill(false, CalculateBonus(wis));
            nature = new Skill(false, CalculateBonus(inte));
            perception = new Skill(true, CalculateBonus(wis, true));
            performance = new Skill(false, CalculateBonus(cha));
            persuasion = new Skill(false, CalculateBonus(cha));
            religion = new Skill(false, CalculateBonus(inte));
            slightOfHand = new Skill(false, CalculateBonus(dex));
            stealth = new Skill(false, CalculateBonus(dex));
            survival = new Skill(true, CalculateBonus(wis, true));

            pasPerception = 13;
            pasInvestigation = 12;
            pasInvestigation = 13;
            darkVision = 60;

            
            //Defining Spell slots and remain spells
            spellSlots[0] = new Spell(Mathf.Infinity, Mathf.Infinity); //Cantrips
            spellSlots[1] = new Spell(4, 4);    // Level 1
            spellSlots[2] = new Spell(3, 3);    // Level 2
            spellSlots[3] = new Spell();    // Level 3
            spellSlots[4] = new Spell();    // Level 4
            spellSlots[5] = new Spell();    // ...
            spellSlots[6] = new Spell();   
            spellSlots[7] = new Spell();    
            spellSlots[8] = new Spell();
            spellSlots[9] = new Spell();
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