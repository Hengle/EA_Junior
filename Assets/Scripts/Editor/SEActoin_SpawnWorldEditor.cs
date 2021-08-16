using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
[CustomEditor(typeof(SEActoin_SpawnWorld))]
public class SEActoin_SpawnWorldEditor : SEAction_BaseActionEditor
{
    SEActoin_SpawnWorld owner;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        owner = (SEActoin_SpawnWorld)target;

        #region ��Чʵ������
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("��Чʵ��������");

        var tmpEffect = EditorGUILayout.ObjectField((Object)owner.effectspawnInst,typeof(GameObject),false) as GameObject;
        if(tmpEffect != owner.effectspawnInst)
        {
            owner.effectspawnInst = tmpEffect;
            EditorUtility.SetDirty(owner.gameObject);
        }

        EditorGUILayout.EndHorizontal();
        #endregion

        #region ��Ч�ҽ������
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("��Ч�ҽ������");
        string socketName = EditorGUILayout.TextField(owner.socketName);
        if(socketName != owner.socketName)
        {
            owner.socketName = socketName;
            EditorUtility.SetDirty(owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region ��Ч������ʱʱ��
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        float delayTime = EditorGUILayout.FloatField("��Ч������ʱʱ��", owner.effectDestroyDelay);
        if (delayTime != owner.effectDestroyDelay)
        {
            owner.effectDestroyDelay = delayTime;
            EditorUtility.SetDirty(owner.gameObject);
        }
        #endregion

        #region ��Ч�ֲ�λ��ƫ��
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        Vector3 tmpLocal = EditorGUILayout.Vector3Field("��Ч�ֲ�λ��ƫ��",owner.offSet);
        if(tmpLocal != owner.offSet)
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
