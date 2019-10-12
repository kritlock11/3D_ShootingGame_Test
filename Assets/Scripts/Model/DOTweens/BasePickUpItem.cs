using UnityEngine;

namespace Geekbrains
{
    public abstract class BasePickUpItem : MonoBehaviour
    {
        public Collider coll;
        public bool isDestroy = true;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                coll = other;
                Action();
                if (isDestroy) Destroy(gameObject);
            }
        }
        public abstract void Action();
    }
}
