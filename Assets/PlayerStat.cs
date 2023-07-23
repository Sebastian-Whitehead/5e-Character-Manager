using System;
using System.Collections;
using System.Collections.Generic;
using Settings_menu;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStat : MonoBehaviour, ISettingsEvent
{
    [SerializeField] private TextMeshProUGUI bigNumField, smallNumField, titleField;
    public bool invert;
    public Settings sett;

    private void Start()
    {
        sett.updateSettings.AddListener(UpdateSettings);
    }

    public void UpdateSettings()
    {
        invert = Settings.InvertAbility;
    }

    public void PopulateField(string title, int stat, int bonus)
    {
        titleField.text = title;
        switch (invert)
        {
            case true:
                bigNumField.text = Shared.BonusToString(bonus);
                smallNumField.text = stat.ToString();
                break;
            case false:
                bigNumField.text = stat.ToString();
                smallNumField.text = Shared.BonusToString(bonus) ;
                break;
        }
    }
}
