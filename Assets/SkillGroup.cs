using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillGroup : MonoBehaviour
{
    public SavingThrowElement svElement;
    public List<SkillElement> skillElements;
    
    public void LoadSkillList(Dictionary<string, Skill> skills)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            var entry = skills.ElementAt(i);
            skillElements[i].PopulateField($"{entry.Key}", entry.Value.Bonus, entry.Value.BaseVal, entry.Value.ProfLevel);
        }
    }
}
