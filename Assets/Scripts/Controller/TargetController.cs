using System;
using UnityEngine;


namespace Geekbrains
{
    public class TargetController : BaseController, IOnUpdate, IInitialization
    {
        private TargetsModel TargetsModel;
        Main Main;

        public void Init()
        {
            Main = ServiceLocator.GetService<Main>();
            TargetsModel = ServiceLocator.GetService<TargetsModel>();
        }

        public void OnUpdate()
        {
            UiInterface.SelectedItemUI_Text.Text = String.Empty;
            if (Physics.Raycast(TargetsModel.MainCamera.ScreenPointToRay(TargetsModel.Center), out var hit, TargetsModel.DedicateDistance))
            {
                SelectObject(hit.collider.gameObject);
                TargetsModel.NullString = false;
            }
            else if (!TargetsModel.NullString)
            {
                UiInterface.SelectionObjMessageUi.Text = String.Empty;
                TargetsModel.NullString = true;
                TargetsModel.DedicatedObj = null;
                TargetsModel.IsSelectedObj = false;
                TargetsModel.IsGrabedObj = false;
            }
            if (TargetsModel.IsSelectedObj)
            {
                switch (TargetsModel.SelectedObj)
                {
                    case BaseObjectWeapon aim:
                        if (Vector3.Distance(hit.collider.gameObject.transform.position, Camera.main.transform.position) <= 5)
                        {
                            bool tr = false;
                            if (!tr)
                            {
                                UiInterface.SelectedItemUI_Text.transform.parent.GetComponent<PickUpCanvasRotation>().Rotate();
                                UiInterface.SelectedItemUI_Text.transform.position = hit.collider.transform.position + Vector3.up * 0.5f;
                                UiInterface.SelectedItemUI_Text.Text = "\"T\" to Pick Up";
                                tr = true;
                            }
                            if (Input.GetKeyDown(KeyCode.T))
                            {
                                Main.Inventory.AddWeapon(aim);
                            }
                        }
                        break;

                    case EnemyModel EM:
                        bool rr = false;
                        if (!rr)
                        {
                            var s = EM.GetComponentInChildren<EnemyUI_Slider>();
                            var t = EM.GetComponentInChildren<EnemyUI_Text>();

                            s.MaxFill = EM.GetComponent<EnemyModel>().MaxHp;
                            s.Fill = EM.GetComponent<EnemyModel>().Hp;

                            bool b = s && t;
                            if (EM.StateBot != StateBot.Died)
                            {
                                s.transform.parent.position = EM.transform.position + Vector3.up * 2.5f;
                                s.transform.parent.GetComponent<PickUpCanvasRotation>().Rotate();

                                if (t)
                                {
                                    t.Text = s.transform.parent.parent.GetComponent<EnemyModel>().Defense.ToString();
                                    if (s.transform.parent.parent.GetComponent<EnemyModel>().Defense <= 0)
                                    {
                                        t.transform.parent.gameObject.SetActive(false);
                                    }
                                }
                                rr = true;
                            }

                        }
                        break;
                }
            }
        }

        private void SelectObject(GameObject obj)
        {
            if (obj == TargetsModel.DedicatedObj) return;
            TargetsModel.SelectedObj = obj.GetComponent<ISelectObj>();
            TargetsModel.IGrabObj = obj.GetComponent<IGrabObj>();

            var distanse = Vector3.Distance(obj.transform.position, TargetsModel.MainCamera.transform.position);

            if (TargetsModel.SelectedObj != null)
            {
                UiInterface.SelectionObjMessageUi.Text = $"{distanse:0.0}m / {TargetsModel.SelectedObj.GetMessage()}";
                TargetsModel.IsSelectedObj = true;
            }
            else if (TargetsModel.IGrabObj != null)
            {
                UiInterface.SelectionObjMessageUi.Text = $"To Stole {TargetsModel.IGrabObj.GetText()} Press \"E\"";
                TargetsModel.IsGrabedObj = true;
            }
            else
            {
                UiInterface.SelectionObjMessageUi.Text = String.Empty;
                TargetsModel.IsSelectedObj = false;
            }
            TargetsModel.DedicatedObj = obj;
        }
    }
}
