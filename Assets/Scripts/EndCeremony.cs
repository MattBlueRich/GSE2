using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndCeremony : MonoBehaviour
{
    public List<Sprite> customers;
    private SpriteRenderer customerSpriteRenderer;
    public GameObject customer;
    public GameObject oracle;
    public Words wordsScript;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public Animator anim;
    public AudioSource audiosource;


    void Start()
    {
        customerSpriteRenderer = customer.GetComponent<SpriteRenderer>();

        customerSpriteRenderer.sprite = customers[Random.Range(0, customers.Count)];

        wordsScript.GetFortuneText();
        scoreText.SetText("Score: " + PlayerPrefs.GetFloat("curScore").ToString());
        audiosource.Play();

        if (PlayerPrefs.GetFloat("highScore") == PlayerPrefs.GetFloat("curScore"))
        {
            highScoreText.SetText("New Highscore! " + PlayerPrefs.GetFloat("highScore").ToString());

        }
        else
        {
            highScoreText.SetText("Highscore: " + PlayerPrefs.GetFloat("highScore").ToString());
        }

    }

    void Update()
    {

    }
}