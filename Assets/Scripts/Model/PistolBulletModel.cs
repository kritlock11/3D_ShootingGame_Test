using UnityEngine;
namespace Geekbrains
{
    public class PistolBulletModel : BaseAmmunition
    {
        public AmmunitionType Type = AmmunitionType.PistolBullet;

        private void OnEnable()
        {
            transform.GetComponent<Rigidbody>().WakeUp();
            DestroyAmmunition(_timeToDestruct);
        }
        private void OnDisable()
        {
            transform.GetComponent<Rigidbody>().Sleep();
            CancelInvoke();
        }
        private void OnCollisionEnter(Collision collision)
        {
            var tempObj = collision.gameObject.GetComponent<ISetDamage>();
            if (tempObj != null)
            {
                if (collision.gameObject.GetComponent<PistolBulletModel>())
                {
                    return;
                }
                tempObj.SetDamage(new InfoCollision(_curDamage, Rigidbody.velocity));
            }
            gameObject.SetActive(false);
        }
    }
}
