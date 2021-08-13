using UnityEngine;

public class UI_JoyStick : MonoBehaviour
{
    public CommomJoyBtn commomJoyBtn;

    public Vector3 Dir => (commomJoyBtn.Dir);
}
