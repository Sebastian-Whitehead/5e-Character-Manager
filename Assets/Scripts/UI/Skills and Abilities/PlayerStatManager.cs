using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using UnityEngine;

namespace UI.Skills_and_Abilities
{
    public class PlayerStatManager : MonoBehaviour
    {
        public List<PlayerStat> fieldList;
        
        public void LoadAbilityScoreList(SortedDictionary<string, AbilityScore> abilities, PlayerCharacter passedCharacter)
        {
            for (int i = 0; i < abilities.Count; i++)
            {
                var entry = abilities.ElementAt(i);
                fieldList[i].PopulateField($"{entry.Key}", entry.Value.Score, entry.Value.Bonus, passedCharacter);
            }
        }
    }
}