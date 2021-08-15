using UnityEngine;

public class FinalSkillBtn : CommomJoyBtn
{
    public Color normalColor;
    public Color DisabledColor;
    public CanvasGroup canvasGroupInst;

    public void SetFinalSkillState(bool on)
    {
        canvasGroupInst.blocksRaycasts = on;

        imageBackGround.color = (on) ? normalColor : DisabledColor;
        imageHandle.color = (on) ? normalColor : DisabledColor;
    }
}
