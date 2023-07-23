using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SavingThrowElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt_label, txt_bonus;
    [SerializeField] private Toggle tgl_prof;
    [SerializeField] private Button btn_Edit, btn_Roll;
    private PlayerCharacter _pc;
    private int _bonus;
    private string _key;

    private void Start()
    {
        tgl_prof.onValueChanged.AddListener(delegate { ProfToggleChanged(tgl_prof); });
        btn_Edit.onClick.AddListener(Edit);
        btn_Roll.onClick.AddListener(Roll);
        
        //TODO: Find roll engine by tag
    }

    

    // Standard initialization field
    public void PopulateField(int bonus, bool prof, string key, PlayerCharacter passedCharacter)
    {
        txt_bonus.text = Shared.BonusToString(bonus);
        tgl_prof.isOn = prof;
        _bonus = bonus;
        _pc = passedCharacter;
        _key = key;
    }
    
    // Overload with passed label
    public void PopulateField(int bonus, bool prof, string label, string key, PlayerCharacter passedCharacter)
    {
        PopulateField(bonus, prof, key, passedCharacter);
        txt_label.text = label;
    }



    // ---------------------------------------- Supporting Functions ----------------------------------------------- //
    
    //Called on toggle value changed
    private void ProfToggleChanged(Toggle toggle)
    {
        _bonus = toggle.isOn switch
        {
            true => _pc.AbilityScores[_key].Bonus + _pc.profBonus,
            false => _pc.AbilityScores[_key].Bonus - _pc.profBonus
        };
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
