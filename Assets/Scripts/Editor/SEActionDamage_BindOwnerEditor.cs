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

        #region �˺��ҽӽ������
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("��Ч�ҽ������");
        string socketName = EditorGUILayout.TextField(owner.socketName);
        if (socketName != owner.socketName)
        {
            owner.socketName = socketName;
            EditorUtility.SetDirty(owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region ��Ч�ֲ�λ��ƫ��
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        Vector3 tmpLocal = EditorGUILayout.Vector3Field("��Ч�ֲ�λ��ƫ��", owner.offSet);
        if (tmpLocal != owner.offSet)
        {
            owner.offSet = tmpLocal;
            EditorUtility.SetDirty(owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region ��Ч�ֲ���תƫ��
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        Vector3 tmpLocalRot = EditorGUILayout.Vector3Field("��Ч�ֲ�λ����ת", owner.offRot);
        if (tmpLocalRot != owner.offRot)
        {
            owner.offRot = tmpLocalRot;
            EditorUtility.SetDirty(owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion


    }
}
