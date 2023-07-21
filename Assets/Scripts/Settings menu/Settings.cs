using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Settings_menu
{
    public class Settings : MonoBehaviour
    {
        public UnityEvent updateSettings;
        
        public static bool InvertAbility;

        private void Start()
        {
            updateSettings?.Invoke();
        }
    }

    interface ISettingsEvent
    {
        public void UpdateSettings();
    }
}
