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
    public int angryIncrease = 10;
    public Image heightLight1;
    public Image heightLight2;
    public bool showFinalSkillBtn => (sliderInst.value >= 100);

    public void OnModifyFSV()
    {
        var angryValue = sliderInst.value;
        sliderInst.value += angryIncrease;
        if (sliderInst.value >= 100 && angryValue < 100)
        {
            heightLight1.enabled = true;
        }
        else if (sliderInst.value >= 200 && angryValue < 200)
        {
            heightLight2.enabled = true;
        }
        finalSkillBtnInst.SetFinalSkillState(showFinalSkillBtn);

    }
    #endregion

    #region FinalSkill
    public FinalSkillBtn finalSkillBtnInst;
    #endregion
}
