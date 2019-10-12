using System;
using UnityEngine;
namespace Geekbrains
{
    public class RocketModel : BaseAmmunition
    {
        public AmmunitionType Type = AmmunitionType.Rocket;

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
            Explode();
        }

        private void Explode()
        {
            var boomPos = transform.position;

            Collider[] colliders = Physics.OverlapSphere(boomPos, 5);
            foreach (var item in colliders)
            {
                if (item.GetComponent<EnemyModel>())
                {
                    var go = item.gameObject.GetComponent<EnemyModel>();

                    var Obj_1 = item.gameObject.GetComponent<ISetNoDefense>();
                    var Obj_2 = item.gameObject.GetComponent<ISetDamage>();
                    if (Obj_1 != null)
                    {
                        Obj_1.ISetNoDefense();
                        Obj_2.SetDamage(new InfoCollision(go.MaxHp, Rigidbody.velocity));
                    }

                    //go.StateBot = StateBot.Died;
                    go.AgentDisabled();
                    go.SetLegKick();
                }
                if (item.GetComponent<Rigidbody>())
                {
                    item.GetComponent<Rigidbody>().AddExplosionForce(2500, boomPos, 10);
                }
            }
            gameObject.SetActive(false);
        }
    }
}

