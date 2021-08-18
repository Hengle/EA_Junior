using UnityEngine;
using UnityEditor;
using AttTypeDefine;

[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_SkillInfo))]

public class SEAction_SkillInfoEditor : SEAction_BaseActionEditor
{
    private SEAction_SkillInfo owner;

    string[] options2 = new string[] {"��Ч������", "��Ч���Լ�" ,"�˺����Լ�"};

    private void Awake()
    {
        owner = (SEAction_SkillInfo)target;
        owner.objName = "";
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        owner = (SEAction_SkillInfo)target;

        #region ������Ϸ�����ͺ�����
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();
        Rect rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(50));

        EditorGUILayout.LabelField("�½��ű�������");
        int skillBlindType = EditorGUILayout.Popup((int)owner.skillBlindType, options2);
        if (skillBlindType != (int)owner.skillBlindType)
        {
            owner.skillBlindType = (eSkillBlindType)skillBlindType;
            EditorUtility.SetDirty(owner.gameObject);
        }

        EditorGUILayout.EndHorizontal();

        rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(30));
        EditorGUILayout.LabelField("�½��ű�����");
        string objName = EditorGUILayout.TextField(owner.objName);
        if (!owner.objName.Equals(objName))
        {
            owner.objName = objName;
            EditorUtility.SetDirty(owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region ȷ�ϰ�ť
        EditorGUILayout.Space(); EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("������Ϸ����"))
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
