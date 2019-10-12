using UnityEngine;
using DG.Tweening;

namespace Geekbrains
{
	public class PlayerController : BaseController, IOnUpdate, IInitialization
	{
		private readonly IMotor _motor;


		public PlayerController(IMotor motor)
		{
			_motor = motor;
		}

        public void Init()
        {
            var player = GameObject.Find("CubeMiniMap");
            var go = GameObject.CreatePrimitive(PrimitiveType.Plane);
            go.name = "FADESCREEN";
            go.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material_black");
            var pPos = player.transform.position;
            Sequence seq = DOTween.Sequence();
            seq.Append(go.transform.DOMove(new Vector3(pPos.x, pPos.y, pPos.z+0.8f), 0.01f))
                .Join(go.transform.DORotate(Quaternion.AngleAxis(-90, Vector3.right).eulerAngles, 0.01f))
                .AppendCallback(() => go.transform.parent = player.transform.parent)
                .Append(go.GetComponent<MeshRenderer>().material.DOFade(0, 2))
                .AppendCallback(() => Object.Destroy(go));
        }



        public void OnUpdate()
		{
			_motor.Move();
		}
	}
}