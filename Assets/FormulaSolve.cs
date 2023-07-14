using System;
using Dice_rolling;
using TMPro;
using UnityEngine;
using SimpleExpressionEngine;

[RequireComponent(typeof(TMP_InputField))]
public class FormulaSolve : MonoBehaviour
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
        print(result);
        
        return result;
    }
}
