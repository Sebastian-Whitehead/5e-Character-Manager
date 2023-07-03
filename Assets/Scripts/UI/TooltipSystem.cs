using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem _current;
    public Tooltip tooltip;
    private static CanvasGroup _group;

    
    
    
    void Awake()
    {
        _current = this;
        _group = _current.tooltip.gameObject.GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        Hide();
    }

    public static void Show(string content, string header = "")
    {
        _current.tooltip.SetText(content, header);
        _current.tooltip.gameObject.SetActive(true);
        
        LeanTween.value(_group.gameObject, 0, 1, 0.2f).setOnUpdate((float val) =>
        {
            _group.alpha = val;
        }); // Fade in over 0.2 seconds
    }

    public static void Hide()
    {
        _group.alpha = 0;
        _current.tooltip.gameObject.SetActive(false);
    }
}
