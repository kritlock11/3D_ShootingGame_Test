using UnityEngine;
namespace Geekbrains
{
    public class DashAbilityModel: BaseObjectScene
    {
        private float _dashForce;
        private float _dashDuration;
        private Rigidbody _rb;

        public float DashForce { get => _dashForce; private set => _dashForce = value; }
        public float DashDuration { get => _dashDuration; private set => _dashDuration = value; }
        public Rigidbody Rb { get => _rb; private set => _rb = value; }

        //StartCoroutine(Cast());
        protected override void Awake()
        {
            base.Awake();
            _rb = GetComponent<Rigidbody>();
            _dashForce = 50;
            _dashDuration = 0.2f;
        }
    }
}
