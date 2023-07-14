using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class EditField : MonoBehaviour
{
    private TMP_InputField _textUI;
    
    // Start is called before the first frame update
    void Start()
    {
        _textUI = GetComponent<TMP_InputField>();
    }

    public void ClearField()
    {
        _textUI.text = "";
    }

    public void AppendField(String text)
    {
        _textUI.text += text;
    }

    public void ShiftCursor(int nrOfSpaces)
    {
        _textUI.caretPosition += nrOfSpaces;
    }

    public void SetCursorPos(int pos)
    {
        _textUI.caretPosition = pos;
    }
}
