using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Geekbrains
{
    public sealed class KillerConsoleController : BaseController, IInitialization
    {
        private Main _main;
        private string _name;
        public Sprite WeaponImg;
        public string KillerText;
        public string TargetText;
        public GameObject Prefab;
        public Transform ParentPanel;
        public HashSet<EnemyModel> HashEnemyModels;
        public List<KillerConsoleController> ActionList;

        public void Init()
        {
            _main = ServiceLocator.GetService<Main>();
            Prefab = Resources.Load<GameObject>("Panel");
            ParentPanel = GameObject.Find("ActionPanel").transform;
            HashEnemyModels = _main.EnemyController.GetBotList;

            for (int i = 0; i < HashEnemyModels.Count; i++)
            {
                var bot = HashEnemyModels.ElementAt(i);
                bot.OnBotDie += AddAction;                                      
            }
        }

        public void AddAction(string name)
        {
            this._name = name; 
            GameObject newPanel = Object.Instantiate(Prefab, ParentPanel);
            newPanel.GetComponent<KillerConsolePrefab>().SetupPrefab(this);
            //ActionList.Add(newPanel.GetComponent<KillerConsoleController>());
        }

        public void GetAction()
        {
            WeaponImg = UiInterface.SelectedWeaponUiImg.Img;
            KillerText = "Player";
            TargetText = _name;
        }
    }
}
