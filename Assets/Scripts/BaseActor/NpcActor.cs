using UnityEngine;

public class NpcActor : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void GetHit()
    {
        anim.SetTrigger("Base Layer.GetHit");
    }
}
