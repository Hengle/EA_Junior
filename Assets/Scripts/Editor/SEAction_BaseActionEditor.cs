using UnityEngine;
using UnityEditor;
using AttTypeDefine;

[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_BaseAction))]

public class SEAction_BaseActionEditor : Editor
{
    string[] options = new string[] { "�Զ�����", "��������" };
    private SEAction_BaseAction owner;

    Rect rect;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        owner = (SEAction_BaseAction)target;

        #region ������ʽ���Զ�/����
        EditorGUILayout.Space();
        rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(30));

        EditorGUILayout.LabelField("������ʽ");
        int condition = EditorGUILayout.Popup((int)owner.trigType, options);
        if (condition != (int)owner.trigType)
        {
            owner.trigType = (eTrigType)condition;
            EditorUtility.SetDirty(owner.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region ������ʱ
        EditorGUILayout.Space();
        float delayTime = EditorGUILayout.FloatField("��ʱʱ��",owner.delay);
        if(delayTime != owner.delay)
        {
            owner.delay = delayTime;
            EditorUtility.SetDirty(owner.gameObject);
        }
        #endregion
    }
}
