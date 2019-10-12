using UnityEngine;
using DG.Tweening;

namespace Geekbrains
{
    public class HippodromeHorse : BaseObjectScene, ISelectObj
    {
        public HippodromeHorseObj GO;
        private Vector3[] _path;

        protected override void Awake()
        {
            base.Awake();
            //GO = Resources.Load<HippodromeHorseObj>("ScriptableObjects/Horse_1");
            transform.Find("Body").GetComponent<MeshRenderer>().material.color = GO.color;
            _path = new Vector3[2];
            _path[0] = transform.position;
            _path[1] = new Vector3(transform.position.x - 90f, transform.position.y, transform.position.z) ;

        }
        public string GetMessage()
        {
            return Name;
        }
        public void HorseMove()
        {
            transform.DOPath(_path, GO.speed, PathType.Linear).SetEase(Ease.Linear).SetLookAt(0.01f).SetLoops(-1);
        }

    }
}
