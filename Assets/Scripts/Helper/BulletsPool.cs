using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class BulletsPool
    {
        private readonly int _poolSize;
        public List<BaseAmmunition> bullets;
        public BulletsPool(BaseAmmunition ammunition, int poolSize)
        {
            _poolSize = poolSize;
            bullets = new List<BaseAmmunition>();

            for (var i = 0; i < _poolSize; i++)
            {
                var bullet = Object.Instantiate(ammunition);
                bullet.gameObject.SetActive(false);
                bullets.Add(bullet);
            }
        }
    }
}
