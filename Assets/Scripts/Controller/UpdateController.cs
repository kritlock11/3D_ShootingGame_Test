using UnityEngine;

namespace Geekbrains
{
    public class UpdateController : MonoBehaviour
    {
        [HideInInspector] public Main Main;

        private void Awake()
        {
            Main = ServiceLocator.GetService<Main>();
        }

        private void Update()
        {
            for (var i = 0; i < Main._updates.Count; i++)
            {
                Main._updates[i].OnUpdate();
            }
        }
    }
}
