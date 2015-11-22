using UnityEngine;
using System.Collections;

public class NPCPALOJUTUT : MonoBehaviour
{
    Animator anim;
    AudioSource a;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        a = GetComponent<AudioSource>();
    }

    public void setBurnAnimation()
    {
        anim.SetTrigger("Burn");
        Invoke("d", 7);
        a.Play();
    }


    void d()
    {
        anim.enabled = false;
    }
}
