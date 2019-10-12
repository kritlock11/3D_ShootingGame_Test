using UnityEngine;

namespace Geekbrains
{
    public class MiniMap : MonoBehaviour, IInitialization
    {
        Main Main;

        public void Init()
        {
            Main = ServiceLocator.GetService<Main>();
        }

        private void LateUpdate()
        {
            Vector3 pos = Main.Player.transform.position;
            pos.y = transform.position.y;
            transform.position = pos;

            transform.rotation = Quaternion.Euler(90f, Main.Player.rotation.eulerAngles.y, 0f);
        }
    }
}
