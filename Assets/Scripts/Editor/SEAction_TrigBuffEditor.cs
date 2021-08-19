using UnityEngine;
using UnityEditor;
using AttTypeDefine;

[ExecuteInEditMode]
[CustomEditor(typeof(SEAction_TrigBuff))]

public class SEAction_TrigBuffEditor : SEAction_BaseActionEditor
{
    private SEAction_TrigBuff owner;

   // string[] options2 = new string[] {"��Ч������", "��Ч���Լ�" ,"�˺����Լ�"};

    private void Awake()
    {
        owner = (SEAction_TrigBuff)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        owner = (SEAction_TrigBuff)target;

    }
}
