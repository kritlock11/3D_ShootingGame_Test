using UnityEngine;

namespace Geekbrains
{
    public class WeaponsController : BaseController, IOnUpdate
    {
        private BaseObjectWeapon SelectedWeapon;
        //public void Init()
        //{
        //    UiInterface.WeaponUiText.SetActive(false);
        //    UiInterface.SelectedWeaponUiText.SetActive(false);
        //    UiInterface.SelectedWeaponUiImg.SetActive(false);
        //    UiInterface.AmmoUiImg.SetActive(false);
        //    //Off();
        //}
        public void OnUpdate()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SelectedWeapon.Fire();
                UiInterface.WeaponUiText.ShowData(SelectedWeapon.Clip.CountAmmunition, SelectedWeapon.CountClip);
            }
        }
        public override void On(BaseObjectScene weapon)
        {
            if (IsActive) return;
            base.On(weapon);
            SelectedWeapon = weapon as BaseObjectWeapon;
            SelectedWeapon.IsVisible = true;
            UiInterface.WeaponUiText.SetActive(true);
            UiInterface.SelectedWeaponUiText.SetActive(true);
            UiInterface.SelectedWeaponUiImg.SetActive(true);
            UiInterface.AmmoUiImg.SetActive(true);
            UiInterface.WeaponUiText.ShowData(SelectedWeapon.Clip.CountAmmunition, SelectedWeapon.CountClip);

            UiInterface.SelectedWeaponUiText.Text = SelectedWeapon.gameObject.name;
            switch (SelectedWeapon.gameObject.name)
            {
                case "Knife":
                    UiInterface.SelectedWeaponUiImg.Img = Resources.Load<Sprite>("Knife");
                    UiInterface.AmmoUiImg.SpriteSetActive(false);
                    UiInterface.WeaponUiText.SetActive(false);
                    break;
                case "Pistol":
                    UiInterface.SelectedWeaponUiImg.Img = Resources.Load<Sprite>("Pistol");
                    break;
                case "Shotgun":
                    UiInterface.SelectedWeaponUiImg.Img = Resources.Load<Sprite>("ShortGun");
                    break;
                case "Gun":
                    UiInterface.SelectedWeaponUiImg.Img = Resources.Load<Sprite>("Sniper");
                    break;
                case "Bazooka":
                    UiInterface.SelectedWeaponUiImg.Img = Resources.Load<Sprite>("Rocket");
                    break;
                default:
                    UiInterface.AmmoUiImg.SetActive(false);
                    break;
            }
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            SelectedWeapon.IsVisible = false;
            SelectedWeapon = null;
            UiInterface.WeaponUiText.SetActive(false);
            UiInterface.SelectedWeaponUiText.SetActive(false);
            UiInterface.SelectedWeaponUiImg.SetActive(false);
            UiInterface.AmmoUiImg.SetActive(false);
        }

        public void ReloadClip()
        {
            if (SelectedWeapon == null) return;
            SelectedWeapon.ReloadClip();
            UiInterface.WeaponUiText.ShowData(SelectedWeapon.Clip.CountAmmunition, SelectedWeapon.CountClip);
        }

        //public void Init()
        //{
        //    UiInterface.AmmoUiImg.SetActive(false);
        //}
    }
}
