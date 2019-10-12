using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public sealed class ScopeUi : MonoBehaviour
    {
        private Image _img;
        public Image Img { get => _img;}

        private void Awake()
        {
            _img = GetComponent<Image>();
        }
    }
}
