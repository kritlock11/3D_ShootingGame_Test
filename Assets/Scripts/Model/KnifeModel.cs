using UnityEngine;

namespace Geekbrains
{
    public class KnifeModel : BaseObjectWeapon, ISelectObj
    {
        private Animator _anim;
        [SerializeField] protected float _baseDamage = 40;

        protected override void Awake()
        {
            base.Awake();
            _anim = transform.parent.GetComponent<Animator>();
        }

        public override void Fire()
        {
            if (!_isReady) return;
            _anim.SetTrigger("KnifeAttack");
            Invoke(nameof(MeleeAttack), 0.25f);
            _isReady = false;
            Invoke(nameof(ReadyShoot), _rechergeTime);
        }

        private GameObject CheckBloked()
        {
            if (Physics.Raycast(transform.root.position, transform.forward, out var hit, 5f)) return hit.transform.gameObject;
            return null;
        }

        private void MeleeAttack()
        {
            if (CheckBloked()!=null)
            {
                var GO = CheckBloked();
                var Obj_1 = GO.GetComponent<ISetNoDefense>();
                var Obj_2 = GO.GetComponent<ISetDamage>();
                if (Obj_1 != null)
                {
                    Obj_1.ISetNoDefense();
                    Obj_2.SetDamage(new InfoCollision(_baseDamage, Rigidbody.velocity));
                }
            }
        }

        public string GetMessage()
        {
            return Name;
        }
    }
}

