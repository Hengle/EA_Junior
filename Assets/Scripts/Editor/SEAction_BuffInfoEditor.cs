using UnityEngine;
using UnityEditor;
using AttTypeDefine;
[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_BuffInfo))]
public class SEAction_BuffInfoEditor : SEAction_BaseActionEditor
{
    private SEAction_BuffInfo owner;

    string[] options2 = new string[] { "��Ч������", "��Ч���Լ�", "�˺����Լ�" };

    private void Awake()
    {
        owner = (SEAction_BuffInfo)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        owner = (SEAction_BuffInfo)target;
    }
}
