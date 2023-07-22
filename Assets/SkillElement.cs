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
    [SerializeField] private PlayerCharacter pc;
    
    private int _bonus;
    private string _baseSkill, _label;
    private Skill _pcSkill;

    private void Start()
    {
        btn_Roll.onClick.AddListener(RollSkill);
        btn_Edit.onClick.AddListener(EditSkill);
        tgl_Expert.onValueChanged.AddListener(delegate { ExpertToggleChanged(tgl_Expert); });
        tgl_Proficient.onValueChanged.AddListener(delegate { ProfToggleChanged(tgl_Proficient); });
        _pcSkill = pc.SkillList[_baseSkill];
    }

    // Initialization function:
    public void PopulateField(string label, int bonus, string skillBase, ProfLvl prof)
    {
        // Update Text Fields
        txt_Label.text = label;
        txt_Base.text = "(" + skillBase + ")";
        txt_Score.text = BonusToString(bonus);
        
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
    }

    
    // Called when Expertise toggle value is changed
    private void ExpertToggleChanged(Toggle toggle)
    {
        if (toggle.isOn)
        {
            tgl_Proficient.isOn = toggle.isOn;  // Toggle Proficiency to match
            _bonus = pc.AbilityScores[_baseSkill].Bonus + (pc.profBonus * 2); // Calculate New Bonus from base ability score
            _pcSkill.ProfLevel = ProfLvl.Expert;    // Update Prof Level
        }
        _pcSkill.Bonus = _bonus;                // Update pc Bonus Value
        txt_Score.text = BonusToString(_bonus); // Update UI
    }
    
    // Called when Proficiency toggle value is changed
    private void ProfToggleChanged(Toggle toggle)
    {
        if (toggle.isOn)
        {
            _bonus = pc.AbilityScores[_baseSkill].Bonus + pc.profBonus; // Calculate New Bonus from base ability score
            _pcSkill.ProfLevel = ProfLvl.Proficient;    // Update Prof Level
        }
        else
        {
            _bonus = pc.AbilityScores[_baseSkill].Bonus;    // Calculate New Bonus from base ability score
            tgl_Expert.isOn = false;            // Ensure Expertise is off
            _pcSkill.ProfLevel = ProfLvl.None;  // Update Prof Level
        }
        _pcSkill.Bonus = _bonus;                // Update pc Bonus Value
        txt_Score.text = BonusToString(_bonus); // Update UI
    }

    
    // ---------------------------------------- Supporting Functions ----------------------------------------------- //
    private static string BonusToString(int bonus)
    {
        return bonus switch
        {
            > 0 => "+" + bonus,
            < 0 => "-" + bonus,
            _ => bonus.ToString()
        };
    }

    //TODO: Implement RollSkill
    private void RollSkill()
    {
        
    }
    
    //TODO: Implement EditSkill
    private void EditSkill()
    {
        
    }
}
