using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public sealed class Main : MonoBehaviour
    {
        [SerializeField]  public EnemyModel EnemyModelPrefab;
        [SerializeField]  public GameObject[] WallPref;
        [SerializeField]  public GameObject[] WallPoins;
        [HideInInspector] public LegModel LegModel;
        [HideInInspector] public MiniMap MiniMap;
        [HideInInspector] public WallInstantiate WallInstantiate;

        public PhotoController PhotoController { get; private set; }
        public PlayerPrefsData PlayerPrefsData { get; private set; }
        public FlashLightController FlashLightController { get; private set; }
        public InputController InputController { get; private set; }
        public PlayerController PlayerController { get; private set; }
        public TargetController TargetController { get; private set; }
        public ScopeController ScopeController { get; private set; }
        public WeaponsController WeaponsController { get; private set; }
        public DashAbilityController DashAbilityController { get; private set; }
        public TakeObjController TakeObjController { get; private set; }
        public Transform Player { get; private set; }
        public Inventory Inventory { get; private set; }
        public Transform MainCamera { get; private set; }
        public EnemyController EnemyController { get; private set; }
        public SaveDataRepository SaveDataRepository { get; private set; }
        public KillerConsoleController KillerConsoleController { get; private set; }

        public Portal[] Portal { get; private set; }


        public readonly List<IOnUpdate> _updates = new List<IOnUpdate>();
        public readonly List<IInitialization> _inites = new List<IInitialization>();

        private void Awake()
        {

            Player = GameObject.FindGameObjectWithTag("Player").transform;
            MainCamera = Camera.main.transform;
            SaveDataRepository = new SaveDataRepository();

            LegModel = ServiceLocator.GetService<LegModel>();
            _updates.Add(LegModel);

            MiniMap = ServiceLocator.GetService<MiniMap>();
            _inites.Add(MiniMap);

            WallInstantiate = new WallInstantiate();
            _inites.Add(WallInstantiate);

            Inventory = new Inventory();
            _inites.Add(Inventory);

            TargetController = new TargetController();
            _inites.Add(TargetController);
            _updates.Add(TargetController);

            ScopeController = new ScopeController(this);
            _inites.Add(ScopeController);

            TakeObjController = new TakeObjController();
            _inites.Add(TakeObjController);

            WeaponsController = new WeaponsController();
            //_inites.Add(WeaponsController);
            _updates.Add(WeaponsController);
            
            PlayerController = new PlayerController(new UnitMotor(Player));
            _updates.Add(PlayerController);
            _inites.Add(PlayerController);

            FlashLightController = new FlashLightController();
            _inites.Add(FlashLightController);
            _updates.Add(FlashLightController);

            InputController = new InputController();
            _updates.Add(InputController);

            EnemyController = new EnemyController();
            _inites.Add(EnemyController);
            _updates.Add(EnemyController);

            KillerConsoleController = new KillerConsoleController();
            _inites.Add(KillerConsoleController);

            DashAbilityController = new DashAbilityController();
            _inites.Add(DashAbilityController);



            Portal = FindObjectsOfType<Portal>();
            for (int i = 0; i < Portal.Length; i++)
            {
                _updates.Add(Portal[i]);
            }
        }

        private void Start()
        {
            for (int i = 0; i < _inites.Count; i++)
            {
                _inites[i].Init();
            }
            InputController.On();
            TakeObjController.On();
            EnemyController.On();
            KillerConsoleController.On();

            //for (int i = 0; i < Portal.Length; i++)
            //{
            //Portal[i].Init();
            //}

        }
        public void OnStartCoroutine(IEnumerator routine)
        {
            StartCoroutine(routine);
        }
    }
}
