using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public sealed class KillerConsolePrefab : MonoBehaviour
    {
        public Image WeaponImg;
        public TextMeshProUGUI KillerText;
        public TextMeshProUGUI TargetText;
        private KillerConsoleController _action;

        public void SetupPrefab(KillerConsoleController curAction)
        {
            _action = curAction;
            _action.GetAction();
            WeaponImg.sprite = _action.WeaponImg;
            KillerText.text = _action.KillerText;
            TargetText.text = _action.TargetText;
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}
