using UnityEngine;

namespace Geekbrains
{
    public class Inventory : IInitialization
    {
        private Main Main;
        private UiInterface UiInterface;
        private BaseObjectWeapon[] _weapons = new BaseObjectWeapon[5];
        public FlashLightModel FlashLight { get; private set; }
        public BaseObjectWeapon[] Weapons { get => _weapons; set => _weapons = value; }


        public void Init()
        {
            Main = ServiceLocator.GetService<Main>();
            _weapons = Main.Player.GetComponentsInChildren<BaseObjectWeapon>();
            UiInterface = new UiInterface();

            foreach (var weapon in Weapons)
            {
                weapon.IsVisible = false;
            }
            FlashLight = Object.FindObjectOfType<FlashLightModel>();
        }

        public void GetWeapon(int i)
        {
            Main.WeaponsController.Off();
            if (i <= _weapons.Length - 1)
            {
                Main.WeaponsController.On(_weapons[i]);
            }
        }

        public void AddWeapon(BaseObjectWeapon weapon)
        {
            for (int i = 0; i < _weapons.Length; i++)
            {
                if (_weapons[i] != weapon)
                {
                    var w = _weapons[i].transform.parent.Find($"{weapon.name}").gameObject;
                    w.SetActive(true);
                    w.GetComponent<BaseObjectWeapon>().IsVisible = false;
                    Weapons = Main.Player.GetComponentsInChildren<BaseObjectWeapon>();
                    Object.Destroy(weapon.gameObject);
                }
            }

        }

        public void RemoveWeapon(BaseObjectWeapon weapon)
        {

        }
    }
}
