using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class ScopeModel : BaseObjectScene
    {
        [SerializeField]private Camera _mainCam;
        [SerializeField]private GameObject _weaponCam;
        public bool IsScoped;
        private GameObject _weaponInvisible;
        private float _scopeRange;
        private float _normalScope;
        private Animator _anim;

        public Camera MainCam { get => _mainCam; private set => _mainCam = value; }
        public GameObject WeaponCam { get => _weaponCam; private set => _weaponCam = value; }
        public GameObject WeaponInvisible { get => _weaponInvisible; private set => _weaponInvisible = value; }
        public float ScopeRange { get => _scopeRange; private set => _scopeRange = value; }
        public float NormalScope { get => _normalScope; private set => _normalScope = value; }
        public Animator Anim { get => _anim; private set => _anim = value; }

        protected override void Awake()
        {
            base.Awake();
            _anim = GetComponent<Animator>();
            _weaponInvisible = transform.GetChild(0).gameObject;
            IsScoped = false;
            _normalScope = _mainCam.fieldOfView;
            _scopeRange = 5f;
        }
    }
}