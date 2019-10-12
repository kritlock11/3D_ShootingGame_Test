using UnityEngine;

namespace Geekbrains
{
	public sealed class FlashLightController : BaseController, IOnUpdate, IInitialization
	{
		private FlashLightModel _flashLightModel;
		//private FlashLightUiText _flashLightUi;
		//private FlashLightUi_Bar FlashLightUi_Slider;
        public void Init()
        {
            _flashLightModel = ServiceLocator.GetService<FlashLightModel>();//Object.FindObjectOfType<FlashLightModel>();
            UiInterface.LightUiText.SetActive(true);
            UiInterface.FlashLightUiBar.SetActive(true);
            Switch(false);
        }
        public void OnUpdate()
        {
            if (!IsActive) return;
            if (EditBatteryCharge())
            {
                UiInterface.LightUiText.Text = _flashLightModel.BatteryChargeCurrent;
                UiInterface.FlashLightUiBar.Fill = _flashLightModel.BatteryChargeCurrent;
                Rotation();
            }
            else
            {
                Off();
            }
        }
        public void Switch(bool value)
        {
            _flashLightModel.Light.enabled = value;
            _flashLightModel.Light.intensity = 2;
            UiInterface.LightUiText.SetActive(value);
            UiInterface.FlashLightUiBar.SetActive(value);
            if (!value) return;
            _flashLightModel.Light.color = new Color(
                                     Random.Range(0, 1f),
                                     Random.Range(0, 1f),
                                     Random.Range(0, 1f));
            _flashLightModel.Transform.position = _flashLightModel.GoFollow.position + _flashLightModel.VecOffset;
            _flashLightModel.Transform.rotation = _flashLightModel.GoFollow.rotation;
        }

        public void Rotation()
        {
            _flashLightModel.Transform.position = _flashLightModel.GoFollow.position + _flashLightModel.VecOffset;
            _flashLightModel.Transform.rotation = Quaternion.Lerp(_flashLightModel.Transform.rotation, _flashLightModel.GoFollow.rotation, _flashLightModel.Speed * Time.deltaTime);
        }

        public bool EditBatteryCharge()
        {
            if (_flashLightModel.BatteryChargeCurrent > 0)
            {
                _flashLightModel.BatteryChargeCurrent -= Time.deltaTime;
                return true;
            }
            return false;
        }
        public void EditBatteryChargeUp()
        {
            if (_flashLightModel.BatteryChargeCurrent > 0)
            {
                _flashLightModel.BatteryChargeCurrent = Mathf.Clamp(_flashLightModel.BatteryChargeCurrent += 1, 0, _flashLightModel.BatteryChargeMax);
            }
        }
        public bool BatteryRecharge()
        {
            if (_flashLightModel.BatteryChargeCurrent < _flashLightModel.BatteryChargeMax)
            {
                _flashLightModel.BatteryChargeCurrent += Time.deltaTime;
                return true;
            }
            return false;
        }
        public void LightIntensityUp()
        {
            if (_flashLightModel.BatteryChargeCurrent > 0)
            {
                _flashLightModel.Light.intensity += Time.deltaTime * 2;
            }
        }

		public override void On()
		{
			if(IsActive) return;
            if (_flashLightModel.BatteryChargeCurrent <= 0) return;
			if (_flashLightModel == null) return;
			if (UiInterface.LightUiText == null) return;
			if (UiInterface.FlashLightUiBar == null) return;
			base.On();
			Switch(true);
            //UiInterface.LightUiText.SetActive(true);
            //UiInterface.FlashLightUiBar.SetActive(true);
        }

		public override void Off()
		{
			if (!IsActive) return;
			base.Off();
            //EditBatteryChargeUp();
            BatteryRecharge();
            Switch(false);
            //UiInterface.LightUiText.SetActive(false);
            //UiInterface.FlashLightUiBar.SetActive(false);
        }
    }
}