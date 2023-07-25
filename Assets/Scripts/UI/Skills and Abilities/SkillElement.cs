using System;
using Character;
using Dice_rolling;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Skills_and_Abilities
{
    public class SkillElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI txt_Score, txt_Label, txt_Base;
        [SerializeField] private Button btn_Roll, btn_Edit;
        [SerializeField] private Toggle tgl_Expert, tgl_Proficient;
        private PlayerCharacter _pc;
    
        private int _bonus;
        private string _baseSkill;
        private Skill _pcSkill;
    
        private DiceEngine _dice;
    

        private void Start()
        {
            // Listeners:
            btn_Roll.onClick.AddListener(Roll);
            btn_Edit.onClick.AddListener(Edit);
            tgl_Expert.onValueChanged.AddListener(delegate { ExpertToggleChanged(tgl_Expert); });
            tgl_Proficient.onValueChanged.AddListener(delegate { ProfToggleChanged(tgl_Proficient); });
        
            // Systems:
            _dice = GameObject.FindGameObjectWithTag("DiceEngine").GetComponent<DiceEngine>();
        }

        // Initialization function:
        public void PopulateField(string label, int bonus, string skillBase, ProfLvl prof, PlayerCharacter passedCharacter)
        {
            // Update Text Fields
            txt_Label.text = label;
            txt_Base.text = "(" + skillBase + ")";
            txt_Score.text = Shared.BonusToString(bonus);
        
            // Update proficiency and expertise toggles Fields
            switch (prof)
            {
                case ProfLvl.Expert:
                    tgl_Expert.isOn = true;
                    tgl_Proficient.isOn = true;
                    break;
                case ProfLvl.Proficient:
                    tgl_Expert.isOn = false;
                    tgl_Proficient.isOn = true;
                    break;
                case ProfLvl.None:
                    tgl_Expert.isOn = tgl_Proficient.isOn =  false;
                    break;
            }

            _bonus = bonus;
            _baseSkill = skillBase;
            _pc = passedCharacter;
            _pcSkill = _pc.SkillList[_baseSkill];
        }

// ---------------------------------------- Supporting Functions ----------------------------------------------- //
    
        // Called when Expertise toggle value is changed
        private void ExpertToggleChanged(Toggle toggle)
        {
            print("Exp toggled");
            if (toggle.isOn)
            {
                tgl_Proficient.isOn = toggle.isOn;  // Toggle Proficiency to match
                _bonus = _pc.AbilityScores[_baseSkill].Bonus + (_pc.profBonus * 2); // Calculate New Bonus from base ability score
                _pcSkill.ProfLevel = ProfLvl.Expert;    // Update Prof Level
            }
            _pcSkill.Bonus = _bonus;                // Update pc Bonus Value
            txt_Score.text = Shared.BonusToString(_bonus); // Update UI
        }
    
    
        // Called when Proficiency toggle value is changed
        private void ProfToggleChanged(Toggle toggle)
        {
            print("Prof toggled");

            switch (toggle.isOn)
            {
                case true:
                    _bonus = _pc.AbilityScores[_baseSkill].Bonus + _pc.profBonus; // Calculate New Bonus from base ability score
                
                    // TODO: Check weather this actually changes the value (Otherwise new entry may have to replaced)
                    _pcSkill.ProfLevel = ProfLvl.Proficient;    // Update Prof Level
                    break;
                case false:
                    _bonus = _pc.AbilityScores[_baseSkill].Bonus;    // Calculate New Bonus from base ability score
                    tgl_Expert.isOn = false;            // Ensure Expertise is off
                
                    // TODO: Check weather this actually changes the value (Otherwise new entry may have to replaced)
                    _pcSkill.ProfLevel = ProfLvl.None;  // Update Prof Level      
                    break;
            }
            
            // TODO: Check weather this actually changes the value (Otherwise new entry may have to replaced)
            _pcSkill.Bonus = _bonus;                // Update pc Bonus Value
            txt_Score.text = Shared.BonusToString(_bonus); // Update UI
        }
        
        //TODO: Figure out a way to easily roll with advantage
        private void Roll()
        {
            _dice.RollDice(1, 20, _bonus);
        }
    
        //TODO: Implement Edit
        //Should open a popup window with input field and once confirmed should apply changes (Reference an edit window)
        private void Edit()
        {
        
        }

        private void OnDestroy()
        {
            btn_Roll.onClick.RemoveListener(Roll);
            btn_Edit.onClick.RemoveListener(Edit);
            tgl_Expert.onValueChanged.RemoveListener(delegate { ExpertToggleChanged(tgl_Expert); });
            tgl_Proficient.onValueChanged.RemoveListener(delegate { ProfToggleChanged(tgl_Proficient); });
        }
    }
}
