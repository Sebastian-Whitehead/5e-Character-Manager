using System;
using Dice_rolling;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(RngV1))]
    [RequireComponent(typeof(CharacterFunctions))]
    public class CharacterManager : MonoBehaviour
    {
        private CharacterFunctions _pc;
        private  RngV1 _diceRoller;
        
        private void Awake()
        {
        }

        // Start is called before the first frame update
        void Start()
        {
            print("Running");
            _pc = GetComponent<CharacterFunctions>();
            _pc.LoadTestCharacter();
        }
    
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
