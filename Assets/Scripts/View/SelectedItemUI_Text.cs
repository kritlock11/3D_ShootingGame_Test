using UnityEngine;
using TMPro;

namespace Geekbrains
{
    public sealed class SelectedItemUI_Text : MonoBehaviour
    {
        private TextMeshProUGUI _text;


        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }
        public string Text
        {
            set => _text.text = value;
        }

        public void SetActive(bool value)
        {
            _text.gameObject.SetActive(value);
        }
    }
}
