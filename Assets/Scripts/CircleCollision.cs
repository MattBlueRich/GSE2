using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleCollision : MonoBehaviour
{
    public ScoreManager scoreManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fortune"))
        {
            scoreManager.FortuneScore();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Illusion"))
        {
            //Endgame
            SceneManager.LoadScene("GameOver");
        }
    }
}
