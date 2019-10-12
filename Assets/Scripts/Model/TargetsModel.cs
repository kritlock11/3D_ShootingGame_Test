using UnityEngine;

namespace Geekbrains
{
    public class TargetsModel : BaseObjectScene
    {
        public ISelectObj SelectedObj;
        public IGrabObj IGrabObj;
        public GameObject DedicatedObj;
        public bool NullString;
        public bool IsSelectedObj;
        public bool IsGrabedObj; 
        private Vector2 _center;
        private Camera _mainCamera;
        private float _dedicateDistance = 100;

        public Camera MainCamera { get => _mainCamera; private set => _mainCamera = value; }
        public Vector2 Center { get => _center; private set => _center = value; }
        public float DedicateDistance { get => _dedicateDistance; private set => _dedicateDistance = value; }

        protected override void Awake()
        {
            base.Awake();
            _mainCamera = Camera.main;
            _center = new Vector2(Screen.width / 2, Screen.height / 2);
        }
    }
}
