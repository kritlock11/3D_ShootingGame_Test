using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class TakeObjController : BaseController, IInitialization
    {
        private TakeObjModel[] _takeObjModel;

        public void Init()
        {
            //_takeObjModel = Object.FindObjectsOfType<TakeObjModel>();
        }
        private List<TakeObjModel> PlayerNear()
        {
            _takeObjModel = Object.FindObjectsOfType<TakeObjModel>();

            List<TakeObjModel> list = new List<TakeObjModel>();
            for (int i = 0; i < _takeObjModel.Length; i++)
            {
                if (Vector3.Distance(_takeObjModel[i].gameObject.transform.position, _takeObjModel[i].Cam.position) <= 4f)
                    list.Add(_takeObjModel[i]);
            }
            return list;
        }
        public void TakeObj()
        {
            foreach (var item in PlayerNear())
            {
                item.Rigidbody.isKinematic = true;
                item.Transform.parent = item.Cam;
                item.Carried = true;
            }
        }
        public void ThrowObj()
        {
            foreach (var item in PlayerNear())
            {
                if (item.Carried && Input.GetKeyUp(KeyCode.E))
                {
                    item.Rigidbody.isKinematic = false;
                    item.Transform.parent = null;
                    item.Carried = false;
                    item.Rigidbody.AddForce(item.Cam.forward * item.ThrowForce);
                }
            }
        }
    }
}
