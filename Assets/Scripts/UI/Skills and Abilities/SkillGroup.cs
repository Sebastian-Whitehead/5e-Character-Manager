using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Character;
using UnityEngine;

public class SkillGroup : MonoBehaviour
{
    public SavingThrowElement svElement;
    public List<SkillElement> skillElements;
    
    //TODO: Locate dice roller by tag
    //TODO:PASS Dice rolling object to each element so that can call for their relevant roll
    
    
    public void LoadSkillList(SortedDictionary<string, Skill> skills, SavingThrow sv, string svKey, PlayerCharacter pc)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            var entry = skills.ElementAt(i);
            skillElements[i].PopulateField($"{entry.Key}", entry.Value.Bonus, entry.Value.BaseVal, entry.Value.ProfLevel, pc);
        }
        svElement.PopulateField(sv.Bonus, sv.Prof, svKey, pc);
    }
}
