using Dice_rolling;
using Settings_menu;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace UI.Skills_and_Abilities
{
    public class PlayerStat : MonoBehaviour, ISettingsEvent
    {
        private Settings _sett;
        private DiceEngine _dice;
    
        public Button btnEdit, btnRoll;
        [SerializeField] private TextMeshProUGUI txtBigNum, txtSmallNum, txtTitle;
        public bool invert;
        private int _bonus;
    
    

        private void Start()
        {
            // Listeners:
            _sett.updateSettings.AddListener(UpdateSettings);
            btnEdit.onClick.AddListener(Edit);
            btnRoll.onClick.AddListener(Roll);
        
            // Systems:
            _sett = GameObject.FindGameObjectWithTag("SettingsController").GetComponent<Settings>();
            _dice = GameObject.FindGameObjectWithTag("DiceEngine").GetComponent<DiceEngine>();
        }

        public void UpdateSettings()
        {
            invert = Settings.InvertAbility;
        }

        public void PopulateField(string title, int stat, int bonus)
        {
            _bonus = bonus;
            txtTitle.text = title;
            switch (invert)
            {
                case true:
                    txtBigNum.text = Shared.BonusToString(bonus);
                    txtSmallNum.text = stat.ToString();
                    break;
                case false:
                    txtBigNum.text = stat.ToString();
                    txtSmallNum.text = Shared.BonusToString(bonus) ;
                    break;
            }
        }

// --------------------------------------------- Supporting Functions ------------------------------------------ //
        
        //TODO: Figure out a way to easily roll with advantage
        private void Roll()
        {
            _dice.RollDice(1, 20, _bonus);
        }
        
        //TODO: Implement Edit
        //Should open a popup window with input field and once confirmed should apply changes (Reference an edit window)
        private void Edit()
        {
        
        }
    }
}
