using UnityEngine;
using DG.Tweening;

namespace Geekbrains
{
    public class Sheep : BaseObjectScene, ISelectObj
    {
        public Transform[] _sheepPoints;
        private Vector3[] _path;
        private float _pathDuration = 120;
        private Sequence sequence;

        protected override void Awake()
        {
            base.Awake();
            var movePathLength = _sheepPoints.Length;
            _path = new Vector3[movePathLength];

            for (int i = 0; i < movePathLength; i++)
            {
                _path[i] = _sheepPoints[i].position;
            }
            transform.DOPath(_path, _pathDuration, PathType.Linear).SetEase(Ease.InOutSine).SetLookAt(0.01f).SetLoops(-1);
        }
        public string GetMessage()
        {
            return Name;
        }

    }
}
