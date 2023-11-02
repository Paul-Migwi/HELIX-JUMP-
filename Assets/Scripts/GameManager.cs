﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

    public static GameManager singleton;
    public int best;
    public int score;
    public int currentStage = 0;
    

    private void Awake()
    {
        Advertisement.Initialize("5460436");
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);

        // Load the saved highscore
        best = PlayerPrefs.GetInt("Highscore");
    }

    public void NextLevel()
    {
        currentStage++;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
      
    }

    public void RestartLevel()
    {
        Debug.Log("Restarting Level");
        // Show Adds Advertisement.Show();
        Advertisement.Show("5460436");
        singleton.score = 0;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if (score > best)
        {
            PlayerPrefs.SetInt("Highscore", score);
            best = score;
        }
    }


}
