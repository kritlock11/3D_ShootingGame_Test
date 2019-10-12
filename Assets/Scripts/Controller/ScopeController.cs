using System.Collections;
using UnityEngine;

namespace Geekbrains
{
    public sealed class ScopeController : BaseController, IInitialization
    {
        private MonoBehaviour _self;
        private Coroutine _scopeCoroutine;
        private ScopeModel _scopeModel;
        private GameObject _scopeImgGO;
        public ScopeController(MonoBehaviour self)
        {
            _self = self;
        }

        public void Init()
        {
            _scopeModel = Object.FindObjectOfType<ScopeModel>();
            _scopeImgGO = UiInterface.ScopeUi.Img.gameObject;
            Switch(false, _scopeImgGO);
        }

        public override void On()
        {
            if (IsActive) return;
            if (_scopeModel == null) return;
            if (UiInterface.ScopeUi == null) return;
            base.On();
            Switch(true, _scopeImgGO);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            Switch(false, _scopeImgGO);
        }
        public void Switch(bool value, GameObject obj)
        {
            _scopeModel.IsScoped = value;
            _scopeModel.Anim.SetBool("Scoped", _scopeModel.IsScoped);
            if (_scopeModel.IsScoped)
            {
                StartScopeCoroutine(obj);
            }
            else
            {
                OnUnScoped(obj);
                StopScopeCoroutine();
            }
        }
        public void StartScopeCoroutine(GameObject obj)
        {
            _scopeCoroutine = _self.StartCoroutine(OnScoped(obj));
        }
        public void StopScopeCoroutine()
        {
            if (_scopeCoroutine != null)
            {
                _self.StopCoroutine(_scopeCoroutine);
            }
        }
        private void OnUnScoped(GameObject obj)
        {
            obj.SetActive(false);
            _scopeModel.WeaponCam.SetActive(true);
            _scopeModel.MainCam.fieldOfView = _scopeModel.NormalScope;
            _scopeModel.WeaponInvisible.SetActive(true);
        }
        private IEnumerator OnScoped(GameObject obj)
        {
            yield return new WaitForSeconds(0.15f);
            obj.SetActive(true);
            _scopeModel.WeaponCam.SetActive(false);
            _scopeModel.MainCam.fieldOfView = _scopeModel.ScopeRange;
            _scopeModel.WeaponInvisible.SetActive(false);
        }
    }
}