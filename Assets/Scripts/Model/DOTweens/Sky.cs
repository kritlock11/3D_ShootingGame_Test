using UnityEngine;
using DG.Tweening;

namespace Geekbrains
{
    public class Sky : MonoBehaviour
    {
        public Transform[] _skyPoints;
        private Vector3[] _path;
        [Range(50,200), SerializeField] private float _pathDuration = 120;

        private void Awake()
        {
            var movePathLength = _skyPoints.Length;
            _path = new Vector3[movePathLength];

            for (int i = 0; i < movePathLength; i++)
            {
                _path[i] = _skyPoints[i].position;
            }
            transform.DOPath(_path, _pathDuration, PathType.Linear).SetLookAt(0.01f).SetLoops(-1);
        }
    }
}
