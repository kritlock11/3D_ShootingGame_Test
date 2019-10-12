using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using DG.Tweening;

namespace Geekbrains
{
    [CustomEditor(typeof(GreenRoad))]
    public class GreenRoadEditor : Editor
    {
        private GreenRoad gr;
        private Vector3 From;
        private bool ButtonPressed;

        private void Awake()
        {
            gr = (GreenRoad)target;
        }

        public override void OnInspectorGUI()
        {
            if (gr.Items.Count > 0)
            {
                foreach (var item in gr.Items)
                {
                    GUILayout.BeginVertical("box");

                    GUILayout.BeginHorizontal();
                    if (GUILayout.Button("X", GUILayout.Width(20), GUILayout.Height(20)))
                    {
                        gr.Items.Remove(item);
                        break;
                    }

                    if (GUILayout.Button("GO", GUILayout.Width(40), GUILayout.Height(20)))
                    {
                        GoPath(item);
                    }
                    GUILayout.EndHorizontal();

                    item.ID = EditorGUILayout.IntField("ID", item.ID);
                    item.Name = EditorGUILayout.TextField("Name", item.Name);
                    item.GO = (GameObject)EditorGUILayout.ObjectField("GO", item.GO, typeof(GameObject), true);

                    GUILayout.BeginHorizontal();
                    item.Transform = (Transform)EditorGUILayout.ObjectField("From", item.Transform, typeof(Transform), true);
                    var b = GUILayout.Button("+", GUILayout.Width(17), GUILayout.Height(17));
                    GUILayout.EndHorizontal();
                    if (b)
                    {
                        From = item.Transform.position;
                        item.Pos.Add(From);
                    }

                    if (item.Pos.Count>0)
                    {
                        if (item.Transform != null)
                        {
                            for (int i = 0; i < item.Pos.Count; i++)
                            {
                                GUILayout.BeginHorizontal();

                                item.Pos[i] = EditorGUILayout.Vector3Field("", item.Pos.ToArray()[i]);
                                //var x = GUILayout.Button("x", GUILayout.Width(20), GUILayout.Height(20));
                                var x = GUILayout.Button("x", EditorStyles.miniButton, GUILayout.Width(15), GUILayout.Height(15));
                                if (x)
                                {
                                    item.Pos.Remove(item.Pos[i]);
                                }
                                GUILayout.EndHorizontal();
                            }
                        }
                    }

                    GUILayout.EndVertical();
                }
            }
            else EditorGUILayout.HelpBox("THERE IS NO ELEMENTS IN LIST", MessageType.Info);

            if (GUILayout.Button("ADD", GUILayout.Width(40), GUILayout.Height(20)))
            {
                gr.Items.Add(new Item());
            }

            if (EditorSceneManager.GetActiveScene() == null && GUI.changed)
            {
                SetObjectDirty(gr.gameObject);
            }
        }

        public void GoPath(Item item)
        {
            if (item.Pos != null && item.GO != null)
            {
                item.GO.transform.DOPath(item.Pos.ToArray(), 3, PathType.Linear).SetLoops(-1);
            }
            else
            {
                Debug.Log("NO PATH POINTS");
            }
        }

        private void SetObjectDirty(GameObject go)
        {
            EditorUtility.SetDirty(go);
            EditorSceneManager.MarkSceneDirty(go.scene);
        }
    }
}


