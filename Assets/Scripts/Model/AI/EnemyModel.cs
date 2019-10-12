using System;
using UnityEngine;
using UnityEngine.AI;

namespace Geekbrains
{
    public class EnemyModel : BaseObjectScene, ISelectObj, ISetDamage, ISetScale, ISetNoDefense, ISetLegKick
    {
        public Main Main;

        public event Action OnPointChange;
        public event Action<string> OnBotDie;
        public event Action<EnemyModel> OnDieChange;

        [SerializeField] private float _hp;
        [SerializeField] private float _maxHp;
        [SerializeField] private float _defense;
        public Transform Target { get; set; }
        [SerializeField] private StateBot _stateBot;
        private float startTimer = 5f;
        private float timer;
        private float td;
        private float _waitTime = 1f;
        private bool _isDead = false;
        private Vector3 _point;
        public Vision Vision;
        private NavMeshPath _path;
        private BaseObjectWeapon BaseObjectWeapon;
        public StateBot StateBot
        {
            get => _stateBot;
            set
            {
                _stateBot = value;
                switch (value)
                {
                    case StateBot.Non:
                        Color = Color.white;
                        break;
                    case StateBot.Patrol:
                        Color = Color.green;
                        break;
                    case StateBot.Inspection:
                        Color = Color.yellow;
                        break;
                    case StateBot.Detected:
                        Color = Color.red;
                        break;
                    case StateBot.Died:
                        Color = Color.gray;
                        break;
                    default:
                        Color = Color.white;
                        break;
                }

            }
        }
        public NavMeshAgent Agent { get; private set; }
        public float Hp { get => _hp; private set => _hp = value; }
        public float Defense { get => _defense; private set => _defense = value; }
        public float MaxHp { get => _maxHp; private set => _maxHp = value; }

        protected override void Awake()
        {
            base.Awake();
            Main = ServiceLocator.GetService<Main>();

            Agent = GetComponent<NavMeshAgent>();
            _path = new NavMeshPath();
            timer = startTimer;
        }

        public void Tick()
        {
            td = Time.deltaTime;
            if (StateBot == StateBot.Died) return;

            if (StateBot != StateBot.Detected)
            {
                if (!Agent.hasPath)
                {
                    if (StateBot != StateBot.Inspection)
                    {
                        if (StateBot != StateBot.Patrol)
                        {
                            StateBot = StateBot.Patrol;
                            _point = Patrol.GenericPoint(transform);

                            MovePoint(_point);
                            Agent.stoppingDistance = 0;
                        }
                        else
                        {
                            if (Vector3.Distance(_point, transform.position) <= 2f)
                            {
                                StateBot = StateBot.Inspection;
                                Invoke(nameof(ReadyPatrol), _waitTime);
                            }
                        }
                    }
                }

                if (Vision.VisionM(transform, Target))
                {
                    StateBot = StateBot.Detected;
                }
            }
            else
            {
                MovePoint(Target.position);
                Agent.stoppingDistance = 2;

                timer -= td;
                if (timer <= 0)
                {
                    if (!Vision.VisionM(transform, Target) && Vector3.Distance(Target.position, transform.position) >= 10f)
                    {
                        if (Agent.enabled)
                        {
                            Agent.ResetPath();
                        }
                        StateBot = StateBot.Non;
                        timer = startTimer;
                    }
                }
                //if (Vision.VisionM(transform, Target))
                //{
                //    //todo остановиться 
                //    BaseObjectWeapon.Fire();
                //}
            }
        }

        public void SetDamage(InfoCollision info)
        {
            if (_isDead) return;
            if (_defense > 0)
            {
                _defense -= 1;
            }
            else if (_defense <= 0 && _hp > 0)
            {
                OnPointChange?.Invoke();
                _hp -= info.Damage;
            }

            if (_hp <= 0)
            {
                StateBot = StateBot.Died;
                Agent.enabled = false;
                OnBotDie?.Invoke(gameObject.name);
                OnDieChange?.Invoke(this);
                _isDead = true;
                if (gameObject)
                {

                gameObject.AddComponent<Rigidbody>().AddForce((transform.position- Main.Player.transform.position).normalized * 5, ForceMode.VelocityChange);
                }
                Destroy(gameObject,2);
            }
        }

        public string GetMessage()
        {
            return gameObject.name;
        }

        public void SetScale(InfoCollision info)
        {
            transform.localScale = new Vector3(5, 5, 5);
        }

        public void SetLegKick()
        {
            AgentDisabled();
            if (!gameObject.GetComponent<Rigidbody>())
            {
                gameObject.AddComponent<Rigidbody>();
                gameObject.AddComponent<TakeObjModel>();
            }
        }
        public void AgentDisabled()
        {
            Agent.enabled = false;
        }


        public void ISetNoDefense()
        {
            if (_isDead) return;
            if (_defense > 0)
            {
                _defense = 0;
            }
        }

        private void ReadyPatrol()
        {
            StateBot = StateBot.Non;
        }

        public void MovePoint(Vector3 point)
        {
            if (Agent.enabled)
            {
                Agent.SetDestination(point);
            }
        }
    }
}

