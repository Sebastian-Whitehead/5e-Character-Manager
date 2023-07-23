using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt_Score, txt_Label, txt_Base;
    [SerializeField] private Button btn_Roll, btn_Edit;
    [SerializeField] private Toggle tgl_Expert, tgl_Proficient;
    private PlayerCharacter _pc;
    
    private int _bonus;
    private string _baseSkill, _label;
    private Skill _pcSkill;

    private void Start()
    {
        btn_Roll.onClick.AddListener(Roll);
        btn_Edit.onClick.AddListener(Edit);
        tgl_Expert.onValueChanged.AddListener(delegate { ExpertToggleChanged(tgl_Expert); });
        tgl_Proficient.onValueChanged.AddListener(delegate { ProfToggleChanged(tgl_Proficient); });
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
        _label = label;
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
        if (toggle.isOn)
        {
            _bonus = _pc.AbilityScores[_baseSkill].Bonus + _pc.profBonus; // Calculate New Bonus from base ability score
            _pcSkill.ProfLevel = ProfLvl.Proficient;    // Update Prof Level
        }
        else
        {
            _bonus = _pc.AbilityScores[_baseSkill].Bonus;    // Calculate New Bonus from base ability score
            tgl_Expert.isOn = false;            // Ensure Expertise is off
            _pcSkill.ProfLevel = ProfLvl.None;  // Update Prof Level
        }
        _pcSkill.Bonus = _bonus;                // Update pc Bonus Value
        txt_Score.text = Shared.BonusToString(_bonus); // Update UI
    }

    
    
    
    //TODO: Implement Roll
    private void Roll()
    {
        
    }
    
    //TODO: Implement Edit
    private void Edit()
    {
        
    }
}
