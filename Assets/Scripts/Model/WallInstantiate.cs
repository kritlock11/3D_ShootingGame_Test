using UnityEngine;
using UnityEngine.AI;

namespace Geekbrains
{
    public class WallInstantiate : BaseObjectScene, IInitialization
    {
        private Main Main;
        private NavMeshSurface NMS;
        private Transform _root;

        public void Init()
        {
#if UNITY_EDITOR
            WallBreak();
#endif
            WallInst();
            WallBake();
        }
        public void WallInst()
        {
            Main = ServiceLocator.GetService<Main>();
            NMS = FindObjectOfType<NavMeshSurface>();
            _root = new GameObject("Root").transform;

            for (var i = 0; i < Main.WallPoins.Length; i++)
            {
                var r = Random.Range(0, Main.WallPref.Length);
                Instantiate(Main.WallPref[r],
                    Main.WallPoins[i].transform.position,
                    Quaternion.Euler(Main.WallPref[r].transform.rotation.eulerAngles.x,
                                     Main.WallPref[r].transform.rotation.eulerAngles.y,
                                     Main.WallPref[r].transform.rotation.eulerAngles.z), _root).AddComponent<Wall>();
            }
        }
        public void WallBake()
        {
            NMS.BuildNavMesh();
        }

        public void WallBreak()
        {
            var root = GameObject.Find("Root");
            if (root!=null)
            {
                DestroyImmediate(root);
            }
        }
    }
}