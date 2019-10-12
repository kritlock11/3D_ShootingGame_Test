namespace Geekbrains
{
    public class GunModel : BaseObjectWeapon, ISelectObj
    {
        private BulletsPool bulletsPool;

        protected override void Awake()
        {
            base.Awake();
            bulletsPool = new BulletsPool(Ammunition, 10);
        }

        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            if (!Ammunition) return;
            for (int i = 0; i < bulletsPool.bullets.Count; i++)
            {
                if (!bulletsPool.bullets[i].gameObject.activeInHierarchy)
                {
                    bulletsPool.bullets[i].transform.position = transform.GetChild(0).position;
                    bulletsPool.bullets[i].transform.rotation = transform.GetChild(0).rotation;
                    bulletsPool.bullets[i].gameObject.SetActive(true);
                    bulletsPool.bullets[i].AddForce(_barrel.forward * _force);
                    break;
                }
            }
            Clip.CountAmmunition--;
            _isReady = false;
            Invoke(nameof(ReadyShoot), _rechergeTime);
        }

        public string GetMessage()
        {
            return Name;
        }
    }
}

