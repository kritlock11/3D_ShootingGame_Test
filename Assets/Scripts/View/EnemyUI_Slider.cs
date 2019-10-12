using UnityEngine;
using UnityEngine.UI;


namespace Geekbrains
{
    public sealed class EnemyUI_Slider : MonoBehaviour
    {
        private Slider _fill;
        private Slider _maxFill;
        private void Awake()
        {
            _fill = GetComponent<Slider>();
            _maxFill = GetComponent<Slider>();
        }
        public float Fill
        {
            set => _fill.value = value;
        }
        public float MaxFill
        {
            set => _maxFill.maxValue = value;
        }
        public void SetActive(bool value)
        {
            _fill.gameObject.SetActive(value);
        }
    }
}
