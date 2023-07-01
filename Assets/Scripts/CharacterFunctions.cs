using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterFunctions : PlayerCharacter
{
    public void Damage(int dmg, bool crit) //Dmg character
    {
        // Check if player is already down and apply failed death saves
        if (health == 0)
        {
            DS_fail++;
            if (crit) DS_fail++;
        }

        // Apply dmg to temp hp first
        tempHealth -= dmg; 
        dmg = tempHealth * -1;
        
        health -= dmg; // Remaining dmg applied to health
        
        if (health <= maxHealth * -1) DS_fail = 3; // Massive Dmg Check

        // If health is bellow 0 set to 0
        if (health < 0)
        {
            health = 0;
            conscious = false;
        }
    }

    public void Heal(int hp)
    {
        health += hp;
        if (health >= maxHealth) health = maxHealth;
        if (health > 0) conscious = true;
    }

    public void CheckDS()
    {
        if 
    }

    //TODO: Long rest
    //TODO: Short rest
    //TODO: Add to inventory
    //TODO: Expend Spell
    //TODO: Manage Spell
    //TODO: Check Death Saves
}
