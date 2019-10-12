using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace Geekbrains
{
    public class GreenRoad : MonoBehaviour
    {
        public List<Item> Items;
    }

    [System.Serializable]
    public class Item
    {
        public int ID;
        public string Name;
        public GameObject GO;
        public Transform Transform;
        public List<Vector3> Pos = new List<Vector3>();
    }
}
