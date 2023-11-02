using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoSpin : MonoBehaviour
{
    public float turnSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.forward, turnSpeed*Time.deltaTime);
    }
}
