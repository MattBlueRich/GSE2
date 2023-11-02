using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> illusions; // List of the possible illusion prefabs that can spawn
    [SerializeField]
    private List<GameObject> fortunes; // List of the possible fortune prefabs that can spawn
    [SerializeField]
    private List<GameObject> spawnPoints; // List of the possible spawn points

    [SerializeField]
    private int timeBetweenSpawns; // List of the possible spawn points

    public List<GameObject> illusionsInGame; //List of the illusions currently in the game scene (dont edit in inspector)
    public List<GameObject> fortunesInGame; //List of the fortunes currently in the game scene (dont edit in inspector)

    [SerializeField]
    private float maxSize = 1.25f; // This is the maximum size an illusion can spawn as.
    [SerializeField]
    private float minSize = 0.75f; // This is the minimum size an illusion can spawn as.

    AudioSource audioSource; // This is used to play ambient twinkling sounds when the fortune appears on screen.
    [Header("Audio")]
    public AudioClip twinkleSFX; // Twinkle SFX.


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //StartCoroutine(Spawner()); // Starts the coroutine to spawn entitys

        StartCoroutine(BeginSpawner());
    }

    void Update()
    {
      

    }


    void SpawnIllusion()
    {
        int illusionNumber = Random.Range(0, illusions.Count); // Chooses random illusion from list to spawn
        GameObject illusionObject = illusions[illusionNumber];
        
        float randomScale = Random.Range(minSize, maxSize); // Pick a random scale size for GameObject.

        GameObject illusionInGame = Instantiate(illusionObject, RandomSpawnPoint().position, Quaternion.identity); // Spawns object at random spawn point
        illusionInGame.transform.localScale = new Vector3(randomScale, randomScale, randomScale); // Gives object random scale

        illusionsInGame.Add(illusionInGame); // Adds illusion to list of illusions in game
    }

    void SpawnFortune()
    {
        // Same thing with illusions but with fortunes

        int fortuneNumber = Random.Range(0, fortunes.Count);
        GameObject fortuneObject = fortunes[fortuneNumber];

        GameObject fortuneInGame = Instantiate(fortuneObject, RandomSpawnPoint().position, Quaternion.identity);

        fortunesInGame.Add(fortuneInGame);

    }

    Transform RandomSpawnPoint()
    {
        // Chooses random spawn point from list
        
        int spawnPointNumber = Random.Range(0, spawnPoints.Count);
        GameObject spawnPointObj = spawnPoints[spawnPointNumber];

        return spawnPointObj.transform;
    }

    IEnumerator Spawner()
    {
        // Calls the function and waits in the right order

        SpawnIllusion();
        yield return new WaitForSeconds(timeBetweenSpawns);
        SpawnIllusion();
        yield return new WaitForSeconds(timeBetweenSpawns);
        SpawnIllusion();
        yield return new WaitForSeconds(timeBetweenSpawns);
        SpawnIllusion();
        yield return new WaitForSeconds(timeBetweenSpawns);
        SpawnFortune();
        audioSource.PlayOneShot(twinkleSFX); // Plays sfx when fortune spawned.
        yield return new WaitForSeconds(timeBetweenSpawns);
        StartCoroutine(Spawner());

    }

    IEnumerator BeginSpawner()
    {
        yield return new WaitForSeconds(2.3f);
        StartCoroutine(Spawner());
    }
}
