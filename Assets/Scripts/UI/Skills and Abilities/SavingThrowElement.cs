using Character;
using Dice_rolling;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Skills_and_Abilities
{
    public class SavingThrowElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI txt_label, txt_bonus;
        [SerializeField] private Toggle tgl_prof;
        [SerializeField] private Button btn_Edit, btn_Roll;
        private PlayerCharacter _pc;
        private DiceEngine _dice;
        private int _bonus;
        private string _key;
        private SavingThrow _pcSavingThrow;


        private void Start()
        {
            // Listeners:
            tgl_prof.onValueChanged.AddListener(delegate { ProfToggleChanged(tgl_prof); });
            btn_Edit.onClick.AddListener(Edit);
            btn_Roll.onClick.AddListener(Roll);
        
            // Systems:
            _dice = GameObject.FindGameObjectWithTag("DiceEngine").GetComponent<DiceEngine>();
            
            // Init:
            _pcSavingThrow = _pc.SavingThrows[_key];
        }

    

        // Standard initialization field
        public void PopulateField(int bonus, bool prof, string key, PlayerCharacter passedCharacter)
        {
            txt_bonus.text = Shared.BonusToString(bonus);
            tgl_prof.isOn = prof;
            _bonus = bonus;
            _pc = passedCharacter;
            _key = key;
        }
    
        // Overload with passed label
        public void PopulateField(int bonus, bool prof, string label, string key, PlayerCharacter passedCharacter)
        {
            PopulateField(bonus, prof, key, passedCharacter);
            txt_label.text = label;
        }


// ---------------------------------------- Supporting Functions ----------------------------------------------- //
    
        //Called on toggle value changed
        private void ProfToggleChanged(Toggle toggle)
        {
            switch (toggle.isOn)
            {
                case true:
                    _bonus += _pc.profBonus;
                    break;
                case false:
                    _bonus -= (_pc.profBonus * 2);
                    break;
            }
            
            // TODO: Check weather this actually changes the value (Otherwise new entry may have to replaced)
            _pcSavingThrow.Bonus = _bonus;
        }

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
