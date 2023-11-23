using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayPulseAnimation : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        //anim.SetBool("CanPlay", false);
      //  StartCoroutine(Delay());
    }

 

    public void Appear()
    {
        anim.SetBool("CanPlay", true);

    }
}

