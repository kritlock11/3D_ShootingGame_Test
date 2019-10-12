using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Geekbrains
{
    public class EnemyController : BaseController, IInitialization, IOnUpdate
    {
        Main Main;
        public int CountBot = 10;
        public HashSet<EnemyModel> GetBotList { get; } = new HashSet<EnemyModel>();

        public void Init()
        {
            Main = ServiceLocator.GetService<Main>();
            UiInterface.TargetsLeftUi.Text = "";

            for (var index = 0; index < CountBot; index++)
            {
                var tempBot = Object.Instantiate(Main.EnemyModelPrefab,
                    Patrol.GenericPoint(Main.Player),
                    Quaternion.identity);

                tempBot.Agent.avoidancePriority = index;
                tempBot.Target = Main.Player; //todo разных противников
                AddBotToList(tempBot);
                tempBot.OnDieChange += RemoveBotFromList;
            }
        }

        private void AddBotToList(EnemyModel bot)
        {
            if (!GetBotList.Contains(bot))
            {
                GetBotList.Add(bot);
            }
        }

        public void RemoveBotFromList(EnemyModel bot)
        {
            if (GetBotList.Contains(bot))
            {
                bot.OnBotDie -= bot.Main.KillerConsoleController.AddAction;
                bot.OnDieChange -= RemoveBotFromList;
                GetBotList.Remove(bot);
            }
        }

        public void OnUpdate()
        {
            if (!IsActive)
            {
                return;
            }

            if (GetBotList.Count <= 5 && GetBotList.Count > 0)
            {
                UiInterface.TargetsLeftUi.Text = $" { GetBotList.Count.ToString()} / {CountBot.ToString()} ENEMIES LEFT ";
            }
            if (GetBotList.Count == 0)
            {
                UiInterface.TargetsLeftUi.Text = $"  ALL ENEMIES DEADDDD! ";
            }

            for (var i = 0; i < GetBotList.Count; i++)
            {
                var bot = GetBotList.ElementAt(i);
                bot.Tick();
            }
        }
    }
}
