using UnityEngine;

namespace Geekbrains
{
	public sealed class InputController : BaseController, IOnUpdate
	{
        Main Main = ServiceLocator.GetService<Main>();
		private KeyCode _activeFlashLight = KeyCode.F;
		private KeyCode _takeObj = KeyCode.E;
        //private KeyCode _activeTaret = KeyCode.Mouse0;
		private KeyCode _activeScope = KeyCode.Mouse1;
        private KeyCode _reloadClip = KeyCode.R;
        //private KeyCode _dash = KeyCode.LeftShift;

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnUpdate()
		{
			if (!IsActive) return;

			if (Input.GetKeyDown(_activeFlashLight))
			{
                Main.FlashLightController.Switch();
            }
            if (Input.GetKey(_activeFlashLight))
            {
                Main.FlashLightController.LightIntensityUp();
            }
            if (Input.GetKeyDown(_activeScope))
            {
                Main.ScopeController.Switch();
            }
            if (Input.GetKey(_takeObj))
            {
                Main.TakeObjController.TakeObj();
            }
            if (Input.GetKeyUp(_takeObj))
            {
                Main.TakeObjController.ThrowObj();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Main.Inventory.GetWeapon(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Main.Inventory.GetWeapon(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Main.Inventory.GetWeapon(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Main.Inventory.GetWeapon(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Main.Inventory.GetWeapon(4);
            }
            if (Input.GetKeyDown(_reloadClip))
            {
                Main.WeaponsController.ReloadClip();
            }
            //if (Input.GetKeyDown(_dash))
            //{
            //    Main.DashAbilityController.Dash();
            //}
        }
    }
}