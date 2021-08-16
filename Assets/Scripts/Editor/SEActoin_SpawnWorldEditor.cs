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

        #region 特效挂结点名称
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("特效挂结点名称");
        string socketName = EditorGUILayout.TextField(owner.socketName);
        if(socketName != owner.socketName)
        {
            owner.socketName = socketName;
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

        #region 特效局部位置偏移
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        Vector3 tmpLocal = EditorGUILayout.Vector3Field("特效局部位置偏移",owner.offSet);
        if(tmpLocal != owner.offSet)
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
