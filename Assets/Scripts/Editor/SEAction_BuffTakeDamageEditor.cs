using UnityEngine;
using UnityEditor;
using AttTypeDefine;

[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_BuffTakeDamage))]

public class SEAction_BuffTakeDamageEditor : SEAction_BaseActionEditor
{
    private SEAction_BuffTakeDamage owner;

    string[] injuerAnimNames = new string[] { "受伤", "击飞" };

    private void Awake()
    {
        owner = (SEAction_BuffTakeDamage)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        owner = (SEAction_BuffTakeDamage)target;

        //show anim type
        #region 播放动画类型：
        EditorGUILayout.Space();
        var rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(30));

        EditorGUILayout.LabelField("触发方式");
        int condition = EditorGUILayout.Popup((int)owner.trigType, injuerAnimNames);
        if (condition != (int)owner.trigType)
        {
            owner.trigType = (eTrigType)condition;
            EditorUtility.SetDirty(owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

    }
}
