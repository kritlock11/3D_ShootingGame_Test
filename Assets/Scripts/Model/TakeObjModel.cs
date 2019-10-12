using UnityEngine;
namespace Geekbrains
{
    public class TakeObjModel : BaseObjectScene
    {
        private Transform _cam;
        private float _throwForce = 400f;
        public bool HasPlayer;
        public bool Carried;
        public bool Touched;

        public Transform Cam { get => _cam; private set => _cam = value; }
        public float ThrowForce { get => _throwForce; private set => _throwForce = value; }

        protected override void Awake()
        {
            base.Awake();
            _cam = Camera.main.transform;
        }
    }
}
