using UnityEngine;
using UnityEngine.UI;

public class UI_JoyStick : MonoBehaviour
{
    #region System Funcs
    private void Start()
    {
        finalSkillBtnInst.SetFinalSkillState(showFinalSkillBtn);
    }
    #endregion
    #region JoyStick
    public CommomJoyBtn commomJoyBtn;

    public Vector3 Dir => (commomJoyBtn.Dir);
    #endregion

    #region Angry Slider
    public Slider sliderInst;
    public Image hightLight1;
    public Image hightLight2;
    public bool showFinalSkillBtn => (sliderInst.value >= 100);

    public void OnModifyFSV(int value)
    {
        var angryValue = sliderInst.value;
        sliderInst.value += value;

        if (sliderInst.value >= 100 && angryValue < 100)
        {
            hightLight1.enabled = true;
        }
        else if (sliderInst.value >= 200 && angryValue < 200)
        {
            hightLight2.enabled = true;
        }
        else if (sliderInst.value >= 100 && sliderInst.value < 200)
        {
            hightLight1.enabled = true;
            hightLight2.enabled = false;
        }
        else if (sliderInst.value < 100)
        {
            hightLight1.enabled = false;
            hightLight2.enabled = false;
        }
        else if (sliderInst.value >= 200)
        {
            hightLight1.enabled = true;
            hightLight2.enabled = true;
        }
        finalSkillBtnInst.SetFinalSkillState(showFinalSkillBtn);

    }
    #endregion

    #region FinalSkill
    public FinalSkillBtn finalSkillBtnInst;
    #endregion
}
