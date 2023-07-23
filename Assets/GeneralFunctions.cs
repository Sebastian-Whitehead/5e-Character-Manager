using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

static class Shared
{
    // Adds a positive and negative symbol while converting a int to a string
    public static string BonusToString(int bonus)
    {
        return bonus switch
        {
            > 0 => "+" + bonus,
            < 0 => "-" + bonus,
            _ => bonus.ToString()
        };
    }
    
    // Function to calculate bonus from score
    public static int CalculateBonus(float score)
    {
        score -= 10;
        int bonus = (int)Mathf.Floor(score / 2);
        return bonus;
    }
        
    //Function to calculate bonus from score w. proficiency
    public static int CalculateSkillBonus(float score, ProfLvl prof, int profBonus)
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