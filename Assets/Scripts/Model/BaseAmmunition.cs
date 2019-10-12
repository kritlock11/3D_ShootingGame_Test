using UnityEngine;
namespace Geekbrains
{
    public abstract class BaseAmmunition : BaseObjectScene
    {
        [SerializeField] protected float _timeToDestruct = 2;
        [SerializeField] protected float _baseDamage = 10;
        protected float _curDamage;
        protected float _lossOfDamageAtTime = 0.2f;

        protected override void Awake()
        {
            base.Awake();
            _curDamage = _baseDamage;
        }

        public void AddForce(Vector3 dir)
        {
            if (!Rigidbody) return;
            Rigidbody.AddForce(dir);
        }

        protected void DestroyAmmunition(float timeToDestruct = 0)
        {
            Invoke(nameof(SetAF), timeToDestruct);
        }
        void SetAF()
        {
            gameObject.SetActive(false);
        }
        protected void LossOfDamage()
        {
            _curDamage -= _lossOfDamageAtTime;
        }
    }
}
