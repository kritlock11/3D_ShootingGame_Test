using UnityEngine;

namespace Geekbrains
{
    public class ShortGunModel : BaseObjectWeapon, ISelectObj
    {
        private Quaternion _fireRot;
        private Quaternion _randomRot;
        public float spredAngle = 10f;

        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            if (!Ammunition) return;

            for (int i = 0; i < 10; i++)
            {
                var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);
                temAmmunition.Layer = 10;
                _randomRot = Random.rotation;
                _fireRot = Quaternion.RotateTowards(temAmmunition.transform.rotation, _randomRot, Random.Range(0.0f, spredAngle));
                temAmmunition.transform.rotation = _fireRot;
                temAmmunition.AddForce(temAmmunition.transform.forward * _force);
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

