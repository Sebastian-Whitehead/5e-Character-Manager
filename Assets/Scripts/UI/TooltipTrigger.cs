using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private static LTDescr delay;
    public string header;
    
    [Multiline()]
    public string content;
    
    
    
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        //TODO: Choose tweener
        delay = LeanTween.delayedCall(0.5f, () =>
        {
            TooltipSystem.Show(content, header);
        });
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //TODO: Choose tweener
        LeanTween.cancel(delay.uniqueId);
        TooltipSystem.Hide();
    }
}
