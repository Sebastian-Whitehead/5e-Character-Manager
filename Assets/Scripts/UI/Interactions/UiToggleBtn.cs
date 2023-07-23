using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace UI.Interactions
{
    public class UiToggleBtn : MonoBehaviour
    {
        private Button _btn;
        public GameObject obj;
        
        // Start is called before the first frame update
        private void Start()
        {
            _btn = this.GetComponent<Button>();
            _btn.onClick.AddListener(delegate { obj.SetActive(!obj.activeSelf); });
        }
    }
}
