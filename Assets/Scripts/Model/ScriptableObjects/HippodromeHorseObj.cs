using UnityEngine;

namespace Geekbrains
{
    [CreateAssetMenu(menuName = "HIPPO/HORSE", fileName = "Horse")]
    public class HippodromeHorseObj : ScriptableObject
    {
        public Color color;
        public int speed;
    }
}
