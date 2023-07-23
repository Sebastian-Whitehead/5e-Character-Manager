using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Character;
using UnityEngine;

public class SkillGroup : MonoBehaviour
{
    public SavingThrowElement svElement;
    public List<SkillElement> skillElements;
    public PlayerCharacter pc;
    
    public void LoadSkillList(SortedDictionary<string, Skill> skills)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            var entry = skills.ElementAt(i);
            skillElements[i].PopulateField($"{entry.Key}", entry.Value.Bonus, entry.Value.BaseVal, entry.Value.ProfLevel, pc);
        }
    }
    
    //TODO: Implement Saving Throw Element Population;
}
