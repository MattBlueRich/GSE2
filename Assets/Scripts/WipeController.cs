using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WipeController : MonoBehaviour
{
    private Animator animator;
    private Image image;
    private readonly int circleSizeId = Shader.PropertyToID("_CircleSize"); // We assign the shader property a variable to animate with.

    //private bool isIn = false;

    public float circleSize = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();

        AnimateIn(); // Runs the transition when the game starts.

    }

    public void AnimateIn()
    {
        animator.SetTrigger("In"); // <--o-->
    }

    public void AnimateOut()
    {
        animator.SetTrigger("Out"); // -->o<--
    }

    // Update is called once per frame
    void Update()
    {
        image.materialForRendering.SetFloat(circleSizeId, circleSize); // The circleSize shader property works with the scripted variable.
    }
}
