using UnityEngine;

namespace Geekbrains
{
    public sealed class FlashLightModel : BaseObjectScene
    {
        private Light _light;
        private Transform _goFollow;
        private float _speed = 10;
        private float _batteryChargeMax = 10;
        public float BatteryChargeCurrent;
        private Vector3 _vecOffset;

        public Light Light { get => _light; private set => _light = value; }
        public Transform GoFollow { get => _goFollow; private set => _goFollow = value; }
        public Vector3 VecOffset { get => _vecOffset; private set => _vecOffset = value; }
        public float Speed { get => _speed; private set => _speed = value; }
        public float BatteryChargeMax { get => _batteryChargeMax; private set => _batteryChargeMax = value; }

        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            _goFollow = Camera.main.transform;
            _vecOffset = transform.position - _goFollow.position;
            BatteryChargeCurrent = _batteryChargeMax;
        }
    }
}