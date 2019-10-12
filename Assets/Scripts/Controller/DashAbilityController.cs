using System.Collections;
using UnityEngine;
namespace Geekbrains
{
    public class DashAbilityController: IInitialization, ICasteble
    {
        private DashAbilityModel _dashAbilityModel;
        Main Main;
        public void Init()
        {
            Main = ServiceLocator.GetService<Main>();
            _dashAbilityModel = ServiceLocator.GetService<DashAbilityModel>();
        }
        public IEnumerator Cast()
        {
            _dashAbilityModel.Rb.AddForce(Camera.main.transform.forward * _dashAbilityModel.DashForce, ForceMode.VelocityChange);
            yield return new WaitForSeconds(_dashAbilityModel.DashDuration);
            //_dashAbilityModel.Rb.velocity = Vector3.zero;
        }
        public void Dash()
        {
            Main.OnStartCoroutine(Cast());
        }
    }
}
