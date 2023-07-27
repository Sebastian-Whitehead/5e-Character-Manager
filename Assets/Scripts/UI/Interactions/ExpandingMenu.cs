using System;
using System.Data;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace UI.Interactions
{
    public class ExpandingMenu : MonoBehaviour
    {
        
        //TODO: Refactor other scripts to be more accessible in the unity editor in a similar fashion to the following:
        [Header("space between menu items")] 
        [SerializeField] private Vector2 spacing;

        [Space] 
        [Header("Main button rotation")] 
        [SerializeField] private float rotationDuration;
        [SerializeField] Ease rotationEase;
        
        [Space] 
        [Header("Animation")] 
        [SerializeField] private float expandDuration;
        [SerializeField] private float collapseDuration;
        [SerializeField] private Ease expandEase;
        [SerializeField] private Ease collapseEase;
        
        [Space] 
        [Header("Fading")] 
        [SerializeField] private float expandFadeDuration;
        [SerializeField] private float collapseFadeDuration;
        
        [Space] 
        [Header("Other")]
        [SerializeField] private bool rotateFirstButtonSeparately;
        [SerializeField] private float firstButtonRotation;

        private Button _mainButton;
        private ExpandingMenuItem[] _menuItems;
        private bool _isExpanded = false;

        private Vector2 _mainButtonPosition;
        private int _itemsCount;

        private int _d4, _d6, _d8, _d10, _d100, _d12, _d20;
        
        // Start is called before the first frame update
        void Start()
        {
            _itemsCount = transform.childCount - 1;
            _menuItems = new ExpandingMenuItem[_itemsCount];
            for (int i = 0; i < _itemsCount; i++)
            {
                _menuItems[i] = transform.GetChild(i + 1).GetComponent<ExpandingMenuItem>();
            }

            _mainButton = transform.GetChild(0).GetComponent<Button>();
            _mainButton.onClick.AddListener(ToggleMenu);
            _mainButton.transform.SetAsLastSibling();
            
            _mainButtonPosition = _mainButton.transform.position;

            ResetPositions();
            _d4 = _d6 = _d8 = _d10 = _d100 = _d12 = _d20 = 0;
        }

        private void ResetPositions()
        {
            for (int i = 0; i < _itemsCount; i++)
            {
                _menuItems[i].trans.position = _mainButtonPosition;
            }
        }

        public void ToggleMenu()
        {
            _isExpanded = !_isExpanded;
            var startingValue = 0;
            if (_isExpanded)
            {
                //menu opened
                if(rotateFirstButtonSeparately){
                    _menuItems[0].trans
                    .DOMove(_mainButtonPosition + (Shared.Rotate(spacing, firstButtonRotation)), expandDuration)
                    .SetEase(expandEase);
                    startingValue = 1;
                }
                
                for (int i = startingValue; i <_itemsCount; i++) // (Change start value to 0 for reuse)
                {
                    //_menuItems[i].trans.position = _mainButtonPosition + spacing * (i + 1);
                    _menuItems[i].trans.DOMove(_mainButtonPosition + spacing * (i + 1 - startingValue), expandDuration)
                        .SetEase(expandEase);
                    _menuItems[i].img.DOFade(1f, expandFadeDuration).From(0f);
                }
            }
            else
            {
                //menu closed
                if(rotateFirstButtonSeparately){
                    _menuItems[0].trans
                        .DOMove(_mainButtonPosition + (Shared.Rotate(spacing, firstButtonRotation)), collapseDuration)
                        .SetEase(collapseEase);
                    startingValue = 1;
                }
                
                for (int i = startingValue; i < _itemsCount; i++)
                {
                    //_menuItems[i].trans.position = _mainButtonPosition;
                    _menuItems[i].trans.DOMove(_mainButtonPosition, collapseDuration).SetEase(collapseEase);
                    _menuItems[i].img.DOFade(0f, collapseFadeDuration);
                }
                
                // Reset prepared roll
                _d4 = _d6 = _d8 = _d10 = _d100 = _d12 = _d20 = 0;
            }
            
            //rotate main button
            _mainButton.transform
                .DORotate(Vector3.forward * 180f, rotationDuration)
                .From(Vector3.zero)
                .SetEase(rotationEase);
        }

        public void OnItemClick(int index)
        {
            switch (index)
            {
                
                //TODO: Implement the given buttons functionality
                case 0:   // 1st button
                    //TODO: Implement roll list call
                    break;
                case 1:   // 2nd button
                    _d4++;
                    break;
                case 2:   // 3rd button
                    _d6++;
                    break;
                case 3:   // 4th button
                    _d8++;
                    break;
                case 4:   // 5th button
                    _d10++;
                    break;
                case 5:   // 6th button
                    _d12++;
                    break;
                case 6:   // 7th button
                    _d20++;
                    break;
                case 7:   // 8th button
                    _d100++;
                    break;
            }
        }

        public void OnItemRClick(int index)
        {
            switch (index)
            {
                
                //TODO: Implement the given buttons functionality
                case 0:   // 1st button
                    break;
                case 1:   // 2nd button
                    _d4--;
                    break;
                case 2:   // 3rd button
                    _d6--;
                    break;
                case 3:   // 4th button
                    _d8--;
                    break;
                case 4:   // 5th button
                    _d10--;
                    break;
                case 5:   // 6th button
                    _d12--;
                    break;
                case 6:   // 7th button
                    _d20--;
                    break;
                case 7:   // 8th button
                    _d100--;
                    break;
            }
        }
        
        
        // Preventing memory leaks
        private void OnDestroy()
        {
            _mainButton.onClick.RemoveListener(ToggleMenu);
        }

        
    }
}
