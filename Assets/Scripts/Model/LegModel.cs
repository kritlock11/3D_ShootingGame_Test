using UnityEngine;

namespace Geekbrains
{
    public class LegModel : BaseObjectScene, IOnUpdate
    {
        private Animator _anim;
        private bool _isReady;
        private float _rechergeTime=0.2f;

        protected override void Awake()
        {
            base.Awake();
            _anim = GetComponent<Animator>();
            _isReady = true;
        }

        public void Fire()
        {
            if (!_isReady) return;
            _anim.SetTrigger("LegAttack");
            LegAttack();
            _isReady = false;
            Invoke(nameof(AttackReady), _rechergeTime);
        }

        void AttackReady()
        {
            _isReady = true;
        }

        private GameObject CheckBloked()
        {
            if (Physics.Raycast(transform.root.position, transform.forward, out var hit, 5f)) return hit.transform.gameObject;
            return null;
        }

        private void LegAttack()
        {
            if (CheckBloked() != null)
            {
                var GO = CheckBloked();
                var Obj_1 = GO.GetComponent<ISetLegKick>();

                if (GO.GetComponent<EnemyModel>())
                {
                    var Obj_2 = GO.GetComponent<ISetNoDefense>();
                    var Obj_3 = GO.GetComponent<ISetDamage>();
                    if (Obj_2 != null)
                    {
                        Obj_2.ISetNoDefense();
                        Obj_3.SetDamage(new InfoCollision(GO.GetComponent<EnemyModel>().MaxHp, Rigidbody.velocity));
                    }
                    //GO.GetComponent<EnemyModel>().StateBot = StateBot.Died;
                }

                if (Obj_1 != null)
                {
                    Obj_1.SetLegKick();
                    GO.GetComponent<Rigidbody>().AddForce((GO.transform.position - transform.root.position).normalized * 15, ForceMode.VelocityChange);
                }
            }

        }

        public void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Fire();
            }
        }
    }
}

