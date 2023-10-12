using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float moveSpeedIncrementSize;
    public float entityFallIncrementSize;
    public float timePerEntityFallIncrement;
    public float entitySpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncrementSpeed", 1, timePerEntityFallIncrement);
    }

    public void IncrementSpeed()
    {
        entitySpeed += entityFallIncrementSize;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.moveSpeed += Time.deltaTime * moveSpeedIncrementSize;
    }
}
