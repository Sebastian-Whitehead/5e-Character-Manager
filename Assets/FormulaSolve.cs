using System;
using Dice_rolling;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class FormulaSolve : DiceEngine
{
    private String _formula;
    private TMP_InputField _inputField;

    private void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
    }

    private void Update()
    {
        if (!_inputField.isFocused) return;
        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter"))
        {
            Calculate(_inputField.text);
        }
    }

    private void Calculate(String input)
    {
        _formula = input;
    }
    
    /*TODO: Implement a math expression engine
         (https://medium.com/@toptensoftware/writing-a-simple-math-expression-engine-in-c-d414de18d4ce)
          - include dice rolling implementation with □d□
          - include min[val1:val2] max[val1:val2]
          on top of standard ()+-*÷ operators
    */
}
