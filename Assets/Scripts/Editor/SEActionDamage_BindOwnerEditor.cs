using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
[CustomEditor(typeof(SEActionDamage_BindOwner))]
public class SEActionDamage_BindOwnerEditor : SEAction_BaseActionEditor
{
    SEActionDamage_BindOwner owner;


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        owner = (SEActionDamage_BindOwner)target;

        #region 伤害挂接结点名称
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("特效挂结点名称");
        string socketName = EditorGUILayout.TextField(owner.socketName);
        if (socketName != owner.socketName)
        {
            owner.socketName = socketName;
            EditorUtility.SetDirty(owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region 特效局部位置偏移
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        Vector3 tmpLocal = EditorGUILayout.Vector3Field("特效局部位置偏移", owner.offSet);
        if (tmpLocal != owner.offSet)
        {
            owner.offSet = tmpLocal;
            EditorUtility.SetDirty(owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region 特效局部旋转偏移
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        Vector3 tmpLocalRot = EditorGUILayout.Vector3Field("特效局部位置旋转", owner.offRot);
        if (tmpLocalRot != owner.offRot)
        {
            owner.offRot = tmpLocalRot;
            EditorUtility.SetDirty(owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion


    }
}
