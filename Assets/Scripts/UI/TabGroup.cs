using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When a tab button is clicked display game-object of similar index
/// </summary>
public class TabGroup : MonoBehaviour
{
    /// <value>Property <c>tabButtons</c> List of all tab buttons</value>>
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    
    /// <value>Property <c>objectsToSwap</c> List of game-objects which are toggled when tab button of similar index is pressed</value>>
    public List<GameObject> objectsToSwap;

    public void Subscribe(TabButton button)
    {
        tabButtons ??= new List<TabButton>();

        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab != null || button != selectedTab)
        {
            button.background.sprite = tabHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs(); 
    }
    
    public void OnTabSelected(TabButton button)
    {
        if (selectedTab != null)
        {
            selectedTab.Deselect();
        }
        selectedTab = button;
        selectedTab.Select();
        
        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++)
        { 
            objectsToSwap[i].SetActive(i == index);
        }
    }
    
    // Reset tab sprite sprite
    private void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if(selectedTab!= null && button == selectedTab) continue;
            button.background.sprite = tabIdle;
        }
    }
}
