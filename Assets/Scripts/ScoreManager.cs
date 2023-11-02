using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Values")]
    public int fortuneValue = 50; // This is the worth of each fortune collectable.
    public int incrementValue; // This is how much the score increases per second.

    [Header("Score Totals")]
    public float currentScore; // This is the player's current score in the game.
    public float totalScore; // This is the player's score at the end of the game.
    public float highScore; // This is the player's current highscore.

    [Header("Score UI")]
    public TextMeshProUGUI scoreText; // This is the UI TMPRO text which shows the score at the top of the screen.

    [HideInInspector] public bool gameOver; // This bool runs events when the game is over, and while the game is playing.

    private void Awake()
    {
        gameOver = false; // The score should start incrementing when the game begins.

        currentScore = 0; // Player's score is automatically set to zero.
    }
    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("highScore", 0); // Fetches the PlayerPref "highScore", if it doesn't exist, create it and set with value of 0.
        StartCoroutine(ScorePerSecond());
    }
    IEnumerator ScorePerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            UpdateScore(incrementValue);
        }
    }

    private void UpdateScore(float score)
    {
        currentScore += score;
        scoreText.text = "Score: " + currentScore.ToString("F0");
    }

    private void Update()
    {
        if (gameOver) // If player is currently playing game, increment the currentScore per second.
        {
            StopAllCoroutines();
            totalScore = currentScore; // This is the final score at the end of the game.
            SaveScore(); // This compares the totalScore with the highScore, to set new highscores.
        }
    }

    // This function adds to the current score, by the fortuneValue. This is called from [scriptname.cs] when the player touches the Fortune. 
    public void FortuneScore()
    {
        UpdateScore(fortuneValue);
    }

    // This compares the totalScore with the current high score.
    public void SaveScore()
    {
        PlayerPrefs.SetFloat("curScore", currentScore);
        
        if(totalScore > highScore) // Is the total score more than the highscore?
        {
            PlayerPrefs.SetFloat("highScore", totalScore); // Set highscore PlayerPref to totalScore.

            Debug.Log("The new highscore is set to: " + highScore);

            highScore = totalScore;

            PlayerPrefs.Save(); // The highscore is now saved, and can be accessed by other scenes.
        }

        Debug.Log("The highscore remains: " + highScore);
    }

}
