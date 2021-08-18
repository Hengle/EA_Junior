using UnityEngine;

public class NpcActor : BasePlayer
{
    Animator anim;
    protected override void Start()
    {
        base.Start();
    }

    public void GetHit()
    {
        anim.SetTrigger("Base Layer.GetHit");
    }
}
