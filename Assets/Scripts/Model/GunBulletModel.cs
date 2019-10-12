using UnityEngine;
namespace Geekbrains
{
    public class GunBulletModel : BaseAmmunition
    {
        public AmmunitionType Type = AmmunitionType.GunBullet;

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
            var Obj_1 = collision.gameObject.GetComponent<ISetNoDefense>();
            var Obj_2 = collision.gameObject.GetComponent<ISetDamage>();
            if (Obj_1 != null)
            {
                if (collision.gameObject.GetComponent<GunBulletModel>())
                {
                    return;
                }
                Obj_1.ISetNoDefense();
                Obj_2.SetDamage(new InfoCollision(_curDamage, Rigidbody.velocity));
                //if (collision.gameObject.GetComponent<EnemyModel>().Hp<=0)
                //{
                //    collision.gameObject.GetComponent<EnemyModel>().Hp = 0;
                //    collision.gameObject.GetComponent<EnemyModel>().StateBot = StateBot.Died;

                //}
            }
            gameObject.SetActive(false);
        }
    }
}
