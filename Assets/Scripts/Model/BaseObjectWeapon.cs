using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public abstract class BaseObjectWeapon : BaseObjectScene
    {
        public Clip Clip;
        public BaseAmmunition Ammunition;
        [SerializeField] protected Transform _barrel;
        [SerializeField] protected float _force = 999;
        protected float _rechergeTime = 0.2f;
        private int _maxCountAmmunition = 40;
        private int _minCountAmmunition = 20;
        protected AmmunitionType[] _ammunitionType = { AmmunitionType.PistolBullet };
        private int _countClip = 5;
        private Queue<Clip> _clips = new Queue<Clip>();
        public int CountClip => _clips.Count;
        protected bool _isReady = true;
        protected bool _fire = true;

        protected virtual void Start()
        {
            for (var i = 0; i <= _countClip; i++)
            {
                AddClip(new Clip { CountAmmunition = Random.Range(_minCountAmmunition, _maxCountAmmunition) });
            }
            ReloadClip();
        }
        public abstract void Fire();
        protected void ReadyShoot()
        {
            _isReady = true;
        }

        protected void AddClip(Clip clip)
        {
            _clips.Enqueue(clip);
        }

        public void ReloadClip()
        {
            if (CountClip <= 0) return;
            Clip = _clips.Dequeue();
        }


        ////public abstract void Fire(BaseAmmunition ammunition);
        //protected virtual void Update()
        //{
        //                                                   // Тут можно дописать условие: если не выбрано оружие или выбрано не огнестрельное оружие, то не производить подсчеты
        //    //_recharge.Update();                            // Производим подсчеты времени
        //    //if (_recharge.IsEvent())                       // Если закончили отсчет, разрешаем стрелять
        //    //{
        //    //    ReadyShoot();
        //    //}
        //}
    }
}
