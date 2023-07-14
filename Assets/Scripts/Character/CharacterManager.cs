using System;
using Dice_rolling;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(DiceEngine))]
    [RequireComponent(typeof(CharacterFunctions))]
    
    public class CharacterManager : MonoBehaviour
    {
        private CharacterFunctions _pc;

        private void Awake()
        {
        }

        // Start is called before the first frame update
        void Start()
        {
            _pc = GetComponent<CharacterFunctions>();
            _pc.LoadTestCharacter();
        }
    
        // Update is called once per frame
        void Update()
        {
        }


        public void DecodeCharacter()
        {
            //TODO: Decode character from aurora builder
        }
        
        public void SaveCharacter()
        {
            //TODO: Save Character
        }

        public void LoadCharacter()
        {
            //TODO: Load Character
        }

        public void SaveInventory()
        {
            //TODO: Save Character Inventory
        }

        public void LoadInventory()
        {
            //TODO: Load Character Inventory
        }
        
        //TODO: Transfer Inventory
        
    }
}
