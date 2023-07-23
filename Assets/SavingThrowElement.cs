using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UI.Toggle;

public class SavingThrowElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt_label, txt_bonus;
    [SerializeField] private Toggle tgl_prof;
    private PlayerCharacter _pc;
    private int _bonus;
    private string _key;

    private void Start()
    {
        tgl_prof.onValueChanged.AddListener(delegate { ProfToggleChanged(tgl_prof); });
    }

    //Called on toggle value changed
    private void ProfToggleChanged(Toggle toggle)
    {
        _bonus = toggle.isOn switch
        {
            true => _pc.AbilityScores[_key].Bonus + _pc.profBonus,
            false => _pc.AbilityScores[_key].Bonus - _pc.profBonus
        };
    }

    // Standard initialization field
    public void PopulateField(int bonus, bool prof, PlayerCharacter passedCharacter, string key)
    {
        txt_bonus.text = Shared.BonusToString(bonus);
        tgl_prof.isOn = prof;
        _bonus = bonus;
        _pc = passedCharacter;
        _key = key;
    }
    
    // Overload with passed label
    public void PopulateField(int bonus, bool prof, string label, PlayerCharacter passedCharacter, string key)
    {
        PopulateField(bonus, prof, passedCharacter, key);
        txt_label.text = label;
    }

  
}
