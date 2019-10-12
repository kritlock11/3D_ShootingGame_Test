using UnityEngine;

namespace Geekbrains
{
    public class PickUpWeapon : BasePickUpItem
    {
        Main Main;
        private BaseObjectWeapon[] _weapons;
        private int ID;

        public override void Action()
        {
            Main = ServiceLocator.GetService<Main>();
            
            isDestroy = false;

            if (coll.gameObject.CompareTag("Player"))
            {
                _weapons = coll.gameObject.GetComponentsInChildren<BaseObjectWeapon>();
            }
            for (int i = 0; i < _weapons.Length; i++)
            {
                if (_weapons[i].gameObject.name != gameObject.name)
                {
                    var w = _weapons[i].transform.parent.Find($"{gameObject.name}").gameObject;
                    w.SetActive(true);
                    w.GetComponent<BaseObjectWeapon>().IsVisible = false;
                    Main.Inventory.Weapons = coll.gameObject.GetComponentsInChildren<BaseObjectWeapon>();
                    isDestroy = true;
                }
            }
        }
    }
}
