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
    public TextMeshProUGUI outputField;
    public List<String> history = new List<string>();
    private String _lastFormula;
    public HistoryController historyController;

    private int _currentHistoryIndex = 0;

    private void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
        _inputField.onSubmit.AddListener(delegate{Calculate(_inputField.text);});
    }

    private void Update()
    {
        if (!_inputField.isFocused) return;
        if (_inputField.text == "") _currentHistoryIndex = -2;
        outputField.gameObject.SetActive(_lastFormula != "");

        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter"))
        {
            Calculate(_inputField.text);
            _inputField.text = "";
        }
        if (Input.GetKey(KeyCode.C))
        {
            _inputField.text = outputField.text = "";
            _currentHistoryIndex = -2;
            manageHistory("", 0);
        }
        
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            _currentHistoryIndex++;
            _currentHistoryIndex = Math.Min(_currentHistoryIndex, history.Count);
            updateHistoryIndex();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _currentHistoryIndex--;
            _currentHistoryIndex = Math.Max(_currentHistoryIndex, -2);
            updateHistoryIndex();
        }
    }

    private void updateHistoryIndex()
    {
        //print(_currentHistoryIndex);
        if (_currentHistoryIndex == -2) 
            _inputField.text = "";
        else if (_currentHistoryIndex == -1) 
            _inputField.text = _lastFormula.Split(" = ")[0];
        else if (_currentHistoryIndex < history.Count) 
            _inputField.text = history[_currentHistoryIndex].Split(" = ")[0];
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
        public double Max(double a, double b)
        {
            return Math.Max(a, b);
        }

        public double min(double a, double b)
        {
            return Math.Min(a, b);
        }
        public double Min(double a, double b)
        {
            return Math.Min(a, b);
        }

        public double dist(double a, double b)
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }

        public double pow(double a, double b)
        {
            return Math.Pow(a, b);
        }
    }

    private double Calculate(String inputStr)
    {
        _currentHistoryIndex = 0;
        // Create a library of helper function
        var lib = new MyLibrary();

        // Create a context that uses the library
        var ctx = new ReflectionContext(lib);

        var result = Parser.Parse(inputStr).Eval(ctx);
        if (outputField != null)
        {
            // print("Calculating: " + result);
            outputField.text = inputStr + " = " + result;
        }
        manageHistory(inputStr, result);
        _inputField.text = "";
        
        return result;
    }

    private void manageHistory(String formula, double result)
    {
        
        if (!string.IsNullOrEmpty(_lastFormula)) history.Insert(0, _lastFormula);
        _lastFormula = formula + " = " + result;
        if (formula == "") _lastFormula = "";
        // print("lastformula: " + _lastFormula);

        if (history.Count > 3) history.RemoveRange(3, Math.Max(history.Count-3, 0));
        historyController.UpdateHistory(history);
    }

    private void clearHistory()
    {
        history.Clear();
        historyController.UpdateHistory(history);
    }
}
