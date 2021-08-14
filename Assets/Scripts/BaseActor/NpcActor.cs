using UnityEngine;

public class NpcActor : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("Base Layer.GetHit");
        Debug.Log(other.name);
    }
}
