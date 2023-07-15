using System;
using System.Collections.Generic;
using System.Linq;
using Dice_rolling;
using TMPro;
using UnityEngine;
using SimpleExpressionEngine;

[RequireComponent(typeof(TMP_InputField))]
public class FormulaSolve : MonoBehaviour
{
    private String _formula;
    private TMP_InputField _inputField;
    private TextMeshProUGUI _outputField;
    public List<String> history = new List<string>();
    private String _lastFormula;

    private void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
        _inputField.onSubmit.AddListener(delegate{Calculate(_inputField.text);});
    }

    private void Update()
    {
        if (!_inputField.isFocused) return;
        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter"))
        {
            Calculate(_inputField.text);
        }
    }

    class MyLibrary
    {
        public MyLibrary()
        {
            pi = Math.PI;
        }

        public double pi { get; private set; }

        public double max(double a, double b)
        {
            return Math.Max(a, b);
        }

        public double min(double a, double b)
        {
            return Math.Min(a, b);
        }

        public double dist(double a, double b)
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }
    }

    private double Calculate(String inputStr)
    {
        // Create a library of helper function
        var lib = new MyLibrary();

        // Create a context that uses the library
        var ctx = new ReflectionContext(lib);

        var result = Parser.Parse(inputStr).Eval(ctx);
        if (_outputField != null) _outputField.text = result.ToString();
        manageHistory(inputStr, result);
        
        return result;
    }

    private void manageHistory(String formula, double result)
    {
        if (_lastFormula != null) history.Add(_lastFormula);
        _lastFormula = formula + " : " + result;

        if (history.Count > 3) history.RemoveRange(3, Math.Max(history.Count-3, 0));
    }

    private void clearHistory()
    {
        history.Clear();
    }
}
