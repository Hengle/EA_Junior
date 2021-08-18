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

        #region 特效实例对象
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("特效实例化对象");

        var tmpEffect = EditorGUILayout.ObjectField((Object)owner.effectspawnInst,typeof(GameObject),false) as GameObject;
        if(tmpEffect != owner.effectspawnInst)
        {
            owner.effectspawnInst = tmpEffect;
            EditorUtility.SetDirty(owner.gameObject);
        }

        EditorGUILayout.EndHorizontal();
        #endregion

        #region 特效销毁延时时长
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        float delayTime = EditorGUILayout.FloatField("特效销毁延时时长", owner.effectDestroyDelay);
        if (delayTime != owner.effectDestroyDelay)
        {
            owner.effectDestroyDelay = delayTime;
            EditorUtility.SetDirty(owner.gameObject);
        }
        #endregion

        #region 特效Scale
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        float effectScale = EditorGUILayout.FloatField("特效缩放比例", owner.effectScale);
        if (effectScale != owner.effectScale)
        {
            owner.effectScale = effectScale;
            EditorUtility.SetDirty(owner.gameObject);
        }
        #endregion

    }
}
