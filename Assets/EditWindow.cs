using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EditWindow : MonoBehaviour
{
    public TextMeshProUGUI title, placeholder, input;
    public Button BtnConfirm, BtnCancel;
    
    [NonSerialized] public string StrOut, StrIn;
    [NonSerialized] public int IntOut, IntIn;

    public enum Mode
    {
        StringEdit,
        IntEdit
    }

    public Mode currentEditMode;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //TODO: Implement esc = close window and scrap changes
    }
    
    public string EditText(string title, string placeholder)
    {
        string output = "";

        
        return output;
    }

    public int EditNumber(string title, string placeholder)
    {
        int output = 0;


        return output;
    }
    
}
