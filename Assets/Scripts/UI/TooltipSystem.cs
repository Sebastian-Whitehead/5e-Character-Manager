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
        _group = _current.gameObject.GetComponent<CanvasGroup>();
        //_group = _current.tooltip.gameObject.GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        Hide();
    }

    public static void Show(string content, string header = "")
    {
        _current.tooltip.SetText(content, header);
        _current.tooltip.gameObject.SetActive(true);
        LeanTween.alpha(_group.gameObject, 1, 0.3f);

        /* Alternate fade method if the first doesnt work
         
        LeanTween.value(gameObject, 0, 1, 0.3f).setOnUpdate((float val) =>
        {
            _group.alpha = val;
        }); // Fade in over 0.2 seconds
        */
    }

    public static void Hide()
    {
        _group.alpha = 0;
        _current.tooltip.gameObject.SetActive(false);
    }
}
