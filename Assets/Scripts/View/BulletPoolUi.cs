using UnityEngine;
using TMPro;


namespace Geekbrains
{
    public sealed class BulletPoolUi : MonoBehaviour
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
