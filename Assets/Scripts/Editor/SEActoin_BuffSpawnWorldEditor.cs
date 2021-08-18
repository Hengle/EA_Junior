using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_BuffSpawnWorld))]
public class SEActoin_BuffSpawnWorldEditor : SEAction_BaseActionEditor
{
    SEAction_BuffSpawnWorld  owner;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        owner = (SEAction_BuffSpawnWorld)target;

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

        #region ��Ч������ʱʱ��
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        float delayTime = EditorGUILayout.FloatField("��Ч������ʱʱ��", owner.effectDestroyDelay);
        if (delayTime != owner.effectDestroyDelay)
        {
            owner.effectDestroyDelay = delayTime;
            EditorUtility.SetDirty(owner.gameObject);
        }
        #endregion

        #region ��ЧScale
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        float effectScale = EditorGUILayout.FloatField("��Ч���ű���", owner.effectScale);
        if (effectScale != owner.effectScale)
        {
            owner.effectScale = effectScale;
            EditorUtility.SetDirty(owner.gameObject);
        }
        #endregion

    }
}
