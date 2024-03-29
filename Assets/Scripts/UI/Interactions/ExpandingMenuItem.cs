using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Interactions
{
    public class ExpandingMenuItem : MonoBehaviour
    {
        [HideInInspector] public Image img;
        [HideInInspector] public Transform trans;

        private ExpandingMenu _expandingMenu;
        private GUIClickController _button;
        //private Button _button;
        private int _index;
        
        
        void Awake()
        {
            img = GetComponent<Image>();
            trans = transform;

            _expandingMenu = trans.parent.GetComponent<ExpandingMenu>();
            _index = trans.GetSiblingIndex() - 1;

            _button = GetComponent<GUIClickController>();
            _button.onLeft.AddListener(OnItemClick);
            _button.onRight.AddListener(OnItemRClick);
        }

        private void OnItemClick()
        {
            _expandingMenu.OnItemClick(_index);
        }
        
        private void OnItemRClick()
        {
            _expandingMenu.OnItemRClick(_index);
        }

        // Preventing memory leak
        private void OnDestroy()
        {
            _button.onLeft.RemoveListener(OnItemClick);
            _button.onRight.RemoveListener(OnItemRClick);
        }
    }
}
