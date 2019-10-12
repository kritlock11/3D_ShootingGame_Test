using UnityEngine;
using UnityEditor;


namespace Geekbrains
{
    [CustomEditor(typeof(WallInstantiate))]

    public class WallInstantiateEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            WallInstantiate testTarget = (WallInstantiate)target;

            var isPressButton = GUILayout.Button("WallGenerator",
                EditorStyles.miniButtonLeft);

            if (isPressButton)
            {
                testTarget.WallBreak();
                testTarget.WallInst();
            }
        }
    }
}
