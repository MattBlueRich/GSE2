using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleCollision : MonoBehaviour
{
    public ScoreManager scoreManager;

    [Header("Death Animation")]
    public float knockbackForce = 50f;
    public WipeController wipeController;
    public float hitstopDuration;
    public float timeTillLoadScene = 2.3f;

    [Header("Audio")]
    public List<AudioClip> fortunePickupSFX = new List<AudioClip>();
    public List<AudioClip> illusionCollisionSFX = new List<AudioClip>();
    public List<AudioClip> deathExplosionSFX = new List<AudioClip>();
    AudioSource audioSource;

    Rigidbody2D rb;
    private PlayerMovement playerMovement;
    private ScreenShake screenShake;
    private Object explosionRef;
    CircleCollider2D circleCollider2D;
    bool waiting = false;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        screenShake = GetComponent<ScreenShake>();
        circleCollider2D = GetComponent<CircleCollider2D>();

        explosionRef = Resources.Load("DeathExplosion");
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fortune"))
        {
            scoreManager.FortuneScore();
            playSound("pickup"); // Plays pickup sound effect.
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Illusion"))
        {
            // Endgame.
            scoreManager.gameOver = true;
            playerMovement.canMove = false;
            circleCollider2D.enabled = false; // This stops any further collisions with other Illusions.

            playSound("gong"); // Plays gong sound effect.
            HitStop(); // This pauses the game for a few frames, for impact.

            // Explosion particle effect.
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = transform.position;
            Destroy(explosion, 1f);

            // Knockback effect.
            Vector2 difference = (transform.position - collision.transform.position).normalized;
            Vector2 force = difference * knockbackForce;
            rb.AddForce(force, ForceMode2D.Impulse);

            // Waits a couple seconds before moving to next scene.
            StartCoroutine(waitTillDeath());
       
        }
    }

    // This function is known as a "HitStop". This pauses the game for a few frames to give impact to a harsh hit.
    void HitStop()
    {
        if (waiting) // This just makes sure we are definitely only running this function once.
            return;
        Time.timeScale = 0.0f; // Pauses the game.
        StartCoroutine(Wait(hitstopDuration));
    }
    IEnumerator Wait(float duration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(duration); // We use "Realtime" in order to run this function while the game is paused.
        Time.timeScale = 1.0f; // Unpauses the game.
        playSound("death"); // Plays death explosion sound effect.
        waiting = false; // Function can now be called again.
    }

    // This function waits a few seconds after the death animation before we switch to the game over scene.
    IEnumerator waitTillDeath()
    {
        yield return new WaitForSeconds(timeTillLoadScene);
        wipeController.AnimateOut(); // Transition out animation.
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene("GameOver");
    }

    // (Sound state cases: "pickup", "gong", "death")
    void playSound(string state) 
    {
        switch (state)
        {
            case "pickup":
                audioSource.PlayOneShot(fortunePickupSFX[Random.Range(0, fortunePickupSFX.Count)]);
                break;
            case "gong":
                audioSource.PlayOneShot(illusionCollisionSFX[Random.Range(0, fortunePickupSFX.Count)]);
                break;
            case "death":
                audioSource.PlayOneShot(deathExplosionSFX[Random.Range(0, fortunePickupSFX.Count)]);
                break;
        }
    }
}
