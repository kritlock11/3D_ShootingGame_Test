using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class Teleporter : BaseObjectScene// : MonoBehaviour
    {
        public Transform Player;
        public Transform Receiver;
        //private bool _playerIsOverlapping = false;
        private void OnTriggerEnter(Collider other)
        {
            Teleport(other);
            //if (other.gameObject.CompareTag("Player"))
            //{
            //    Teleport(other);
            //}
        }
        private void Teleport(Collider other)
        {

            other.transform.position = Receiver.position+Vector3.up*1.3f;


            //Vector3 portalToPlayer = Player.position - transform.position;
            ////float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            ////if (dotProduct < 0f)
            ////{
            //float rotatDiff = Quaternion.Angle(transform.rotation, Receiver.rotation);
            //rotatDiff += 180;
            //Player.Rotate(Vector3.up, rotatDiff);

            //Vector3 PosOffset = Quaternion.Euler(0f, rotatDiff, 0f) * portalToPlayer;
            //Player.position = Receiver.position + PosOffset;
            //Debug.Log($"Player.position {Player.position}");
            //Debug.Log($"Player.localPosition {Player.localPosition}");
            ////}

        }
        //private void Teleport(Transform obj)
        //{
        //Vector3 localPos = transform.worldToLocalMatrix.MultiplyPoint3x4(obj.position);
        //localPos = new Vector3(localPos.x, -localPos.y, localPos.z);
        //obj.transform.position = Receiver.transform.localToWorldMatrix.MultiplyPoint3x4(localPos);
        //Debug.DrawLine(Player.position, transform.position, Color.red);
        //Debug.Log($"{obj.position}TP============");
        //}
    }
}

