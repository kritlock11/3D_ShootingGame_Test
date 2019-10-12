using UnityEngine;
using TMPro;


namespace Geekbrains
{
    public sealed class SelectionObjMessageUi : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }
        public string Text
        {
            set => _text.text = $"{value}";
        }
        public void SetActive(bool value)
        {
            _text.gameObject.SetActive(value);
        }
    }
}
