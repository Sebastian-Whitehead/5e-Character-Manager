using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DataStructures;
using UnityEngine.UI;



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
    public int[] hitDice;
    
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
    public bool conscious;
    public int DS_sucess;
    public int DS_fail;
    public bool Alive;
    
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
    public int darkvision;

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

    //Spells:
    public int[] spellSlots; //Null if not spell caster
    public int[] expendedSpellSlots;
    public int[] maxKnown;

    
    
    //TODO: Features & Traits
    //TODO: Actions
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        TestCharacter();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void TestCharacter()
    {
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
        
        str = 16;
        dex = 17;
        con = 16;
        inte = 14;
        wis = 13;
        cha = 12;
        
        SV_str = new SavingThrow(true, CalculateBonus(str) + profBonus);
        SV_dex = new SavingThrow(false, CalculateBonus(dex));
        SV_con = new SavingThrow(true, CalculateBonus(con) + profBonus);
        SV_inte = new SavingThrow(false, CalculateBonus(inte));
        SV_wis = new SavingThrow(false, CalculateBonus(wis)); 
        SV_cha = new SavingThrow(false, CalculateBonus(cha));
        
        DS_sucess = 0;
        DS_fail = 0;
        
        acrobatics = new Skill(false, CalculateBonus(dex));
        animalHandling = new Skill(false, CalculateBonus(wis));
        arcana = new Skill(false, CalculateBonus(inte));
        athletics = new Skill(false, CalculateBonus(str) + profBonus);
        deception = new Skill(false, CalculateBonus(cha));
        history = new Skill(false, CalculateBonus(inte));
        insight = new Skill(true, CalculateBonus(wis) + profBonus);
        intimidation = new Skill(true, CalculateBonus(cha) + profBonus);
        investigation = new Skill(false, CalculateBonus(inte));
        medicine = new Skill(false, CalculateBonus(wis));
        nature = new Skill(false, CalculateBonus(inte));
        perception = new Skill(true, CalculateBonus(wis) + profBonus);
        performance = new Skill(false, CalculateBonus(cha));
        persuasion = new Skill(false, CalculateBonus(cha));
        religion = new Skill(false, CalculateBonus(inte));
        slightOfHand = new Skill(false, CalculateBonus(dex));
        stealth = new Skill(false, CalculateBonus(dex));
        survival = new Skill(true, CalculateBonus(wis) + profBonus);

        pasPerception = 13;
        pasInvestigation = 12;
        pasInvestigation = 13;
        darkvision = 60;
    }
    
    public int CalculateBonus(float score)
    {
        score -= 10;
        int bonus = (int)Math.Floor(score / 2);
        return bonus;
    }


}