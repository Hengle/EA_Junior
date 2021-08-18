using UnityEngine;
using UnityEditor;
using AttTypeDefine;

[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_SkillInfo))]

public class SEAction_SkillInfoEditor : SEAction_BaseActionEditor
{
    private SEAction_SkillInfo owner;

    string[] options2 = new string[] {"特效绑定世界", "特效绑定自己" ,"伤害绑定自己"};

    private void Awake()
    {
        owner = (SEAction_SkillInfo)target;
        owner.objName = "";
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        owner = (SEAction_SkillInfo)target;

        #region 输入游戏的类型和名称
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        Rect rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(50));

        EditorGUILayout.LabelField("新建脚本绑定类型");
        int skillBlindType = EditorGUILayout.Popup((int)owner.skillBlindType, options2);
        if (skillBlindType != (int)owner.skillBlindType)
        {
            owner.skillBlindType = (eSkillBlindType)skillBlindType;
            EditorUtility.SetDirty(owner.gameObject);
        }

        EditorGUILayout.EndHorizontal();

        rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(30));
        EditorGUILayout.LabelField("新建脚本名称");
        string objName = EditorGUILayout.TextField(owner.objName);
        if (!owner.objName.Equals(objName))
        {
            owner.objName = objName;
            EditorUtility.SetDirty(owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region 确认按钮
        EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("创建游戏对象"))
        {
            GameObject obj = new GameObject(owner.objName);
            obj.transform.parent = owner.gameObject.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;

            obj.AddComponent<SEAction_DataStore>();

            switch (owner.skillBlindType)
            {
                case eSkillBlindType.eEffectOwner:

                    break;
                case eSkillBlindType.eEffectWorld:
                    obj.AddComponent<SEActoin_SpawnWorld>();
                    break;
                case eSkillBlindType.eDamageOwner:
                    obj.AddComponent<SEActionDamage_BindOwner>();
                    obj.AddComponent<SEAction_Destruction>();
                    var bc = obj.AddComponent<BoxCollider>();
                    bc.isTrigger = true;
                    bc.enabled = false;
                    break;
            }
        }
        EditorGUILayout.EndHorizontal();
        #endregion
    }
}
