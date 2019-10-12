using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Geekbrains
{
    public sealed class FlashLightUi_Targets : MonoBehaviour
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
    }
}
