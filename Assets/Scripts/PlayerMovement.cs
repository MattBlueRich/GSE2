using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;

    [SerializeField]
    float defaultRadius, maxRadius, lerpSpeed;

    public float radius;
    float angle;

    private bool keyPressed;

    [HideInInspector] public bool canMove = true;

    void Start()
    {
        radius = defaultRadius;
    }

    void Update()
    {
        if (canMove)
        {
            angle += (moveSpeed / (radius * Mathf.PI * 2f)) * Time.deltaTime;
            transform.position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;

            if (Input.GetKey(KeyCode.Space))
            {
                radius = Mathf.Lerp(radius, maxRadius, 1 * Time.deltaTime * lerpSpeed);
                keyPressed = true;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                keyPressed = false;
            }

            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    radius = Mathf.Lerp(radius, maxRadius, 1 * Time.deltaTime * lerpSpeed);
                    keyPressed = true;

                }
                if (touch.phase == TouchPhase.Ended)
                {
                    keyPressed = false;

                }

            }


            if (keyPressed == false)
            {
                if (radius != defaultRadius)
                {
                    radius = Mathf.Lerp(radius, defaultRadius, 1 * Time.deltaTime * lerpSpeed);

                }

            }
        }

    }

}

