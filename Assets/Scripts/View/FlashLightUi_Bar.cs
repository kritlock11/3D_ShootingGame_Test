using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public sealed class FlashLightUi_Bar : MonoBehaviour
    {
        private Slider _fill;

        private void Awake()
        {
            _fill = GetComponent<Slider>();
        }

        public float Fill
        {
            set => _fill.value = value;
        }

        public void SetActive(bool value)
        {
            _fill.gameObject.SetActive(value);
        }
    }
}
