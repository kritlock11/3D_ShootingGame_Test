using UnityEngine;
using TMPro;

namespace Geekbrains
{
    public sealed class SelectedWeaponUiText : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        public string Text { get => _text.text; set => _text.text = value; }

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void SetActive(bool value)
        {
            _text.gameObject.SetActive(value);
        }

    }
}
