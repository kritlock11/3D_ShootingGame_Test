using UnityEngine;
using DG.Tweening;

namespace Geekbrains
{
    public class Door : MonoBehaviour
    {
        [SerializeField] Ease _ease;
        private Sequence sequence;
        private Carpet _carpet;
        private Light _doorLight;
        private HippodromeHorse[] _hippodromeHorse;

        private void Awake()
        {
            _carpet = GameObject.Find("Carpet").GetComponent<Carpet>();
            _doorLight = GameObject.Find("DoorLight").GetComponent<Light>();
            _hippodromeHorse = FindObjectsOfType<HippodromeHorse>();
            _carpet.OnCarpenEnter += Cast;
        }
        private void Cast()
        {
            sequence = DOTween.Sequence();

            sequence.Append(transform.DOLocalMoveY(22, 2, false).SetEase(_ease))
                .Insert(0, _doorLight.DOColor(Color.green, 0.1f))
                .AppendInterval(2f)
                .OnComplete(Cast2);
            _carpet.OnCarpenEnter -= Cast;
        }
        private void Cast2()    
        {
            transform.DOLocalMoveY(16, 2, false).SetEase(_ease);
            for (int i = 0; i < _hippodromeHorse.Length; i++)
            {
                _hippodromeHorse[i].HorseMove();
            }
        }
    }
}
