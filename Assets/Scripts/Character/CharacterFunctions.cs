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
        private RngV1 _diceRoller;

        void Awake()
        {
            _diceRoller = GetComponent<RngV1>();
        }
        // ------------------------------------Health & Death Saves---------------------------------------- // 
        /* Damage the character control. This function checks both for dmg while down and applies relevant
         death saving throws. The function also checks for massive dmg as well as controlling the conscious 
         parameter. */
        public void Damage(int dmg, bool crit) 
        {
            if (health == 0) // Check if player is already down and apply failed death saves.
            {
                DS_fail++;
                if (crit) DS_fail++;
            }

            // Apply dmg to temp hp first.
            tempHealth -= dmg; 
            dmg = tempHealth * -1;
            health -= dmg; // Remaining dmg applied to health.
            if (health <= maxHealth * -1) DS_fail = 3; // Massive Dmg Check.
            
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
        public void CheckDeathSaves()
        {
            if (DS_stable) return;
            if (DS_fail >= 3)
            {
                alive = false;
            } else if (DS_sucess >= 3)
            {
                ResetDeathSaves();
            }
        }

        // Reset both successful and failed death saving throws.
        private void ResetDeathSaves()
        {
            DS_fail = DS_sucess = 0;
        }

        // ------------------------------------Resting---------------------------------------- // 
        
        // Short rest functionality: So far only the health regeneration through hit dice. 
        // Using digital dice roll,
        public void ShortRest(int expend)
        {
            expend = Math.Min(expend, HitDice.Remaining);
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
        private void RegainHitDie(int count)
        {
            HitDice.Remaining = Math.Min(HitDice.Remaining + count, HitDice.Total);
        }

        private void LongRest()
        {
            //TODO: Regen spell slots
            
            health = maxHealth;
            RegainHitDie(Math.Max((int)Math.Floor(HitDice.Total/2f), 1));
        }
        
        //TODO: Add to inventory
        //TODO: Expend Spell
        //TODO: Manage Spell
    }
}
