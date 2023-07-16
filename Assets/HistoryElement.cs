using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HistoryElement : MonoBehaviour, IPointerClickHandler
{
    private CanvasGroup _cg;
    public HistoryController historyController;
    public TextMeshProUGUI textField;

    public void Start()
    {
        _cg = GetComponent<CanvasGroup>();
        historyController.Subscribe(this);
    }
    
    public void PopulateElement(String fill)
    {
        textField.text = fill;
        if (fill != "") fadeIn();
    }

    public void fadeIn()
    {
        LeanTween.value(this.gameObject, 0, 1, 0.2f).setOnUpdate((float val) =>
        {
            _cg.alpha = val;
        });
    }

    public void fadeOut()
    {
        LeanTween.value(this.gameObject, 1, 0, 0.2f).setOnUpdate((float val) =>
        {
            _cg.alpha = val;
        });
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        historyController.RecallHistory(this);
    }
}
