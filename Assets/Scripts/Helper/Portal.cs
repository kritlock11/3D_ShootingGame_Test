using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class Portal : BaseObjectScene, IOnUpdate//, IInitialization
    {
        public Portal Other;
        public Camera PortalView;

        //public void Init()
        //{
        //    Other.PortalView.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        //    GetComponent<MeshRenderer>().sharedMaterial.mainTexture = Other.PortalView.targetTexture;
        //}
        public void OnUpdate()
        {
            //Vector3 lookerPosition = Other.transform.worldToLocalMatrix.MultiplyPoint3x4(Camera.main.transform.position);
            ////lookerPosition = new Vector3(lookerPosition.x, -lookerPosition.y, -lookerPosition.z);
            //PortalView.transform.localPosition = lookerPosition;

            Vector3 lookerPosition = Other.transform.worldToLocalMatrix.MultiplyPoint3x4(Camera.main.transform.position);
            lookerPosition = new Vector3(lookerPosition.x, -lookerPosition.y, -lookerPosition.z);
            PortalView.transform.localPosition = lookerPosition;

            Quaternion difference = transform.rotation * Quaternion.Inverse(Other.transform.rotation * Quaternion.Euler(180, 0, 0));
            PortalView.transform.rotation = difference * Camera.main.transform.rotation;
            PortalView.nearClipPlane = (PortalView.transform.position - transform.position).magnitude;//(PortalView.transform.position - transform.position).magnitude;//lookerPosition.magnitude;
            //Debug.DrawLine(transform.position, PortalView.transform.position, Color.red);
            //Debug.Log($"{lookerPosition.magnitude} //{(PortalView.transform.position- transform.position).magnitude} ");
        }
    }
}
