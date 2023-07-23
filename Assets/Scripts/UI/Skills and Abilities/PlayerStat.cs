using System;
using System.Collections;
using System.Collections.Generic;
using Settings_menu;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class PlayerStat : MonoBehaviour, ISettingsEvent
{
    public Button btnEdit, btnRoll;
    [SerializeField] private TextMeshProUGUI txtBigNum, txtSmallNum, txtTitle;
    public bool invert;
    private Settings sett;
    

    private void Start()
    {
        sett.updateSettings.AddListener(UpdateSettings);
        
        //TODO: Find Settings by tag
        //TODO: Find roll engine by tag
    }

    public void UpdateSettings()
    {
        invert = Settings.InvertAbility;
    }

    public void PopulateField(string title, int stat, int bonus)
    {
        txtTitle.text = title;
        switch (invert)
        {
            case true:
                txtBigNum.text = Shared.BonusToString(bonus);
                txtSmallNum.text = stat.ToString();
                break;
            case false:
                txtBigNum.text = stat.ToString();
                txtSmallNum.text = Shared.BonusToString(bonus) ;
                break;
        }
    }
}
