using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HistoryController : MonoBehaviour
{
    public List<HistoryElement> historyElements;
    public TMP_InputField inputField;

    public void Subscribe(HistoryElement element)
    {
        historyElements ??= new List<HistoryElement>();
        historyElements.Add(element);
        element.gameObject.SetActive(false);
    }

    public void UpdateHistory(List<String> history)
    {
        for (int i = 0; i < historyElements.Count; i++)
        {
            if (i < history.Count)
            {
                historyElements[i].gameObject.SetActive(true);
                historyElements[i].PopulateElement(history[i]);
            }
            else
            {
                historyElements[i].gameObject.SetActive(false);
                historyElements[i].PopulateElement("");
            }
        }
    }

    public void RecallHistory(HistoryElement element)
    {
        inputField.text = element.textField.text;
    }
    
    //TODO: Animate introduction and deleting of history elements
}
