using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLights : MonoBehaviour
{

    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("pulseanimation", 1f, Random.Range(1, 10));
    }

    void pulseanimation()
    {
        animator.SetTrigger("IsPulsing");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
