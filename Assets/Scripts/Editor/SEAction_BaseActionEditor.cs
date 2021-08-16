using UnityEngine;
using UnityEditor;
using AttTypeDefine;

[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_BaseAction))]

public class SEAction_BaseActionEditor : Editor
{
    string[] options = new string[] { "自动触发", "条件触发" };
    private SEAction_BaseAction owner;

    Rect rect;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        owner = (SEAction_BaseAction)target;

        #region 触发方式：自动/条件
        EditorGUILayout.Space();
        rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(30));

        EditorGUILayout.LabelField("触发方式");
        int condition = EditorGUILayout.Popup((int)owner.trigType, options);
        if (condition != (int)owner.trigType)
        {
            owner.trigType = (eTrigType)condition;
            EditorUtility.SetDirty(owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region 触发延时
        EditorGUILayout.Space();
        float delayTime = EditorGUILayout.FloatField("延时时长",owner.delay);
        if(delayTime != owner.delay)
        {
            owner.delay = delayTime;
            EditorUtility.SetDirty(owner.gameObject);
        }
        #endregion
    }
}
