using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnRails : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputText;
    [SerializeField] private Slider slider;
    private String _lastText = "";

    public void ShowButton()
    {
        LeanTween.value(slider.gameObject, 0, 1, 0.5f).setOnUpdate((float val) =>
        {
            slider.value = val;
        });
    }
    
    public void HideButton()
    {
        LeanTween.value(slider.gameObject, 1, 0, 0.5f).setOnUpdate((float val) =>
        {
            slider.value = val;
        });
    }

    private void Update()
    {
        //print(inputText.text == "");
        if (_lastText == "" && inputText.text != "")
        {
            ShowButton();
        }else if (_lastText != "" && inputText.text == "")
        {
            HideButton();
        }
        _lastText = inputText.text;
    }
}