using System;
using System.Collections.Generic;
using Dice_rolling;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace Character
{
    public class CharacterFunctions : PlayerCharacter
    {
        private DiceEngine _diceRoller;

        void Awake()
        {
            _diceRoller = GetComponent<DiceEngine>();
        }

        // ------------------------------------Health & Death Saves---------------------------------------- // 
        /* Damage the character control. This function checks both for dmg while down and applies relevant
         death saving throws. The function also checks for massive dmg as well as controlling the conscious 
         parameter. */
        public void Damage(int dmg, bool crit) 
        {
            if (health == 0) // Check if player is already down and apply failed death saves.
            {
                dsFail++;
                if (crit) dsFail++;
            }

            // Apply dmg to temp hp first.
            tempHealth -= dmg; 
            dmg = tempHealth * -1;
            health -= dmg; // Remaining dmg applied to health.
            if (health <= maxHealth * -1) dsFail = 3; // Massive Dmg Check.
            
            if (health <= 0)  // If health is bellow 0 set to 0.
            {
                health = 0;
                conscious = false;
                CheckDeathSaves();
            }
        }
        
        // Heal the character for a given amount of HP.
        public void Heal(int hp)
        {
            health += hp;
            if (health >= maxHealth) health = maxHealth;
            if (health > 0 && alive)
            {
                conscious = true;
                ResetDeathSaves();
            }
        }

        // Revive and heal the character for a specified amount of HP.
        public void RevivePlayer(int hp)
        {
            Heal(hp);
            alive = conscious = true;
        }
        
        // Check current death saving throws.
        private void CheckDeathSaves()
        {
            if (dsStable) return;
            if (dsFail >= 3)
            {
                alive = false;
            } else if (dsSucess >= 3)
            {
                ResetDeathSaves();
            }
        }

        // Reset both successful and failed death saving throws.
        private void ResetDeathSaves()
        {
            dsFail = dsSucess = 0;
        }

        
        
        // ------------------------------------Resting---------------------------------------- // 
        // Short rest functionality: So far only the health regeneration through hit dice. 
        // Using digital dice roll,
        public void ShortRest(int expend)
        {
            expend = Mathf.Min(expend, HitDice.Remaining);
            expend += HitDice.Count;
            
            (int total, List<int> rollList) = _diceRoller.RollDice(expend, HitDice.Size);
            Heal(total);
        }
        
        // Using physical dice roll.
        public void ShortRest(int expend, int hp)
        {
            if (HitDice.Remaining <= 0) return;
            HitDice.Remaining -= expend;
            Heal(hp);
        }
        
        // Regenerate x number of hit dice up to the maximum
        public void RegainHitDie(int count)
        {
            HitDice.Remaining = Mathf.Min(HitDice.Remaining + count, HitDice.Total);
        }

        // Function for long rest
        public void LongRest()
        {
            ResetSpellSlots();
            health = maxHealth;
            RegainHitDie(Mathf.Max((int)Mathf.Floor(HitDice.Total/2f), 1));
        }
        
        
        // ------------------------------------Spells---------------------------------------- // 
        // Expend a single spell slot of a given level
        public bool ExpendSpellSlot(int lvl)
        {
            if (SpellSlots[lvl].Remaining <= 0) return false;   // If no spell slots remaining return.
            SpellSlots[lvl].Remaining--;                        // Expend the spell slot of specified level.
            return true;
        }

        // Reset all spell slots
        public void ResetSpellSlots()
        {
            for (int lvl = 0; lvl < 10; lvl++)
            {
                SpellSlots[lvl].Remaining = SpellSlots[lvl].SpellSlots;
            }
        }
        
        // Regen a number of spell slots of a given level
        public void RegenSpellSlots(int lvl, int nr)
        {
            // Regen spell slots up to the max for a given level
            SpellSlots[lvl].Remaining = Mathf.Min(SpellSlots[lvl].Remaining + nr, SpellSlots[lvl].SpellSlots); 
        }
        
        
        
        //TODO: Add to inventory
        //TODO: Manage Attuned Items
        
        //TODO: Prepare spells
        
        //TODO: Add conditions
        //TODO: add Immunity
        public CharacterFunctions(Dictionary<string, AbilityScore> abilityScores) : base(abilityScores)
        {
        }
    }
}
