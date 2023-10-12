using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPhysics : MonoBehaviour
{ 
    public float moveSpeed = 1f; // How fast the enemies' move to start with

    Rigidbody2D rb2D;

    private ObjectSpawner objectSpawnerScript;

    [SerializeField]
    private bool isIllusion;

    private ProgressionManager progressionManager;

    void Start()
    {
        objectSpawnerScript = GameObject.Find("SpawnManager").GetComponent<ObjectSpawner>(); // Object needs to be called SpawnManager in scene to get the script
         rb2D = gameObject.GetComponent<Rigidbody2D>();
        progressionManager = GameObject.FindGameObjectWithTag("ProgressionManager").GetComponent<ProgressionManager>();
    }

    void Update()
    {
        if (transform.position.y <= -7)
        {
            if(isIllusion == true)
            {
                objectSpawnerScript.illusionsInGame.Remove(gameObject); // Remove illusion from the list of illusions in game and destroys it
                Destroy(gameObject);
            }

            else if (isIllusion == false)
            {
                objectSpawnerScript.fortunesInGame.Remove(gameObject); // Remove fortune from the list of fortunes in game and destroys it
                Destroy(gameObject);
            }
        }

       
    }

    private void FixedUpdate()
    {

        float speed = progressionManager.entitySpeed;

        rb2D.velocity = new Vector2(0, -speed);
    }
}
