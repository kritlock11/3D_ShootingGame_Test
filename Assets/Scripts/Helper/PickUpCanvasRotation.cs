using UnityEngine;

namespace Geekbrains
{
    public class PickUpCanvasRotation: MonoBehaviour
    {
        private Camera cam;
        private void Awake()
        {
            cam = Camera.main;
        }

        public void Rotate()
        {
            transform.rotation = cam.transform.rotation;
        }
    }
}
