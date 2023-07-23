using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace UI.Interactions
{
    public class UiToggleBtn : MonoBehaviour
    {
        private Button _btn;
        public GameObject obj;
        
        // Start is called before the first frame update
        void Start()
        {
            _btn = this.GetComponent<Button>();
            _btn.onClick.AddListener(delegate { obj.SetActive(!obj.activeSelf); });
        }
    }
}
