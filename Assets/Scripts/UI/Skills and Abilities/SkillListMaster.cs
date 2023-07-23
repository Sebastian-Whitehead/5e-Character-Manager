using System.Collections.Generic;
using Character;
using UnityEngine;

namespace UI.Skills_and_Abilities
{
    public class SkillListMaster : MonoBehaviour
    {
        public SkillGroup strGroup, dexGroup, conGroup, intGroup, wisGroup, chaGroup;
        private SortedDictionary<string, Skill> _strList, _dexList, _conList, _intList, _wisList, _chaList;

        public void IntializeSkillLists(Dictionary<string, Skill> masterSkillList, Dictionary<string, SavingThrow> svList, PlayerCharacter passedCharacter)
        {
            // Split the skill list by base value 
            SplitMasterSkillList(masterSkillList);
        
            // Pass the correct list and saving throw to each group manager
            strGroup.LoadSkillList(_strList, svList["str"], "str", passedCharacter); 
            dexGroup.LoadSkillList(_dexList, svList["dex"], "dex", passedCharacter);
            conGroup.LoadSkillList(_conList, svList["con"], "con", passedCharacter);
            intGroup.LoadSkillList(_intList, svList["int"], "int", passedCharacter);
            wisGroup.LoadSkillList(_wisList, svList["wis"], "wis", passedCharacter);
            chaGroup.LoadSkillList(_chaList, svList["cha"], "cha", passedCharacter);
        }

        private void SplitMasterSkillList(Dictionary<string, Skill> masterList)
        {
            foreach (var entry in masterList)
            {
                switch (entry.Value.BaseVal)
                {
                    case "str":
                        _strList.Add(entry.Key, entry.Value);
                        break;
                    case "dex":
                        _dexList.Add(entry.Key, entry.Value);
                        break;
                    case "con":
                        _conList.Add(entry.Key, entry.Value);
                        break;
                    case "int":
                        _intList.Add(entry.Key, entry.Value);
                        break;
                    case "wis":
                        _wisList.Add(entry.Key, entry.Value);
                        break;
                    case "cha":
                        _chaList.Add(entry.Key, entry.Value);
                        break;
                }
            }
        }
    }
}
