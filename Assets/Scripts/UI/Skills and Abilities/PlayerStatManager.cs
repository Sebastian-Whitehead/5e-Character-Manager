using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Settings_menu;
using UI.Skills_and_Abilities;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    public List<PlayerStat> fieldList;

    public void LoadAbilityScoreList(SortedDictionary<string, AbilityScore> abilities)
    {
        for (int i = 0; i < abilities.Count; i++)
        {
            var entry = abilities.ElementAt(i);
            fieldList[i].PopulateField($"{entry.Key}", entry.Value.Score, entry.Value.Bonus);
        }
    }
}