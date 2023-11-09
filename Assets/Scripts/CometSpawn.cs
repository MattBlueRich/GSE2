using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawn : MonoBehaviour
{
    [Header("Comet Object")]
    public GameObject cometPrefab;

    [Header("Comet Math")]
    [Tooltip("This is the distance the comet spawns on the x-axis, positively and negatively (left and right)")]
    public float xDistance = 4;
    public float cometSpeed = 2.0f;
    public float minSpawnRate = 10f;
    public float maxSpawnRate = 20f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnComet", 2f, Random.Range(10, 20));
    }

    void spawnComet()
    {
        int leftOrRight = Random.Range(0, 1); // Picks whether to spawn a comet on the left, or the right side of the screen.

        switch (leftOrRight)
        {
            // Spawn comet on the LEFT side!
            case 0:

                Vector2 spawnPos = new Vector3(-xDistance, Random.Range(-3, 4)); // Spawn on left side of the screen by xDistance, with a y-value between -3 (lowest), and 4 (highest).

                GameObject comet = Instantiate(cometPrefab, spawnPos, Quaternion.identity);

                // Add direction to the comet!

                if(spawnPos.y > 1) // The comet has spawned on the upper-half of the screen, so move a random direction south-east! \.
                {
                    Vector2 direction = new Vector2(Random.Range(0.5f, 1), Random.Range(-0.5f, -1));
                    
                    comet.GetComponent<Rigidbody2D>().AddForce(direction * cometSpeed, ForceMode2D.Impulse);
                }
                else // The comet has spawned on the bottom-half of the screen, so move a random direction north-east! \.
                {
                    Vector2 direction = new Vector2(Random.Range(0.5f, 1), Random.Range(0.5f, 1));

                    comet.GetComponent<Rigidbody2D>().AddForce(direction * cometSpeed, ForceMode2D.Impulse);
                }

                break;

            // Spawn comet on the RIGHT side!
            case 1:

                Vector2 spawnPos1 = new Vector3(xDistance, Random.Range(-3, 4)); // Spawn on right side of the screen by xDistance, with a y-value between -3 (lowest), and 4 (highest).

                GameObject comet1 = Instantiate(cometPrefab, spawnPos1, Quaternion.identity);

                // Add direction to the comet!

                if (spawnPos1.y > 1) // The comet has spawned on the upper-half of the screen, so move a random direction south-west! \.
                {
                    Vector2 direction = new Vector2(Random.Range(-0.5f, -1), Random.Range(-0.5f, -1));

                    comet1.GetComponent<Rigidbody2D>().AddForce(direction * cometSpeed, ForceMode2D.Impulse);
                }
                else // The comet has spawned on the bottom-half of the screen, so move a random direction north-west! \.
                {
                    Vector2 direction = new Vector2(Random.Range(-0.5f, -1), Random.Range(0.5f, 1));

                    comet1.GetComponent<Rigidbody2D>().AddForce(direction * cometSpeed, ForceMode2D.Impulse);
                }

                break;


        }


    }

}
