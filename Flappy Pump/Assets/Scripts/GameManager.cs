using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public GameObject gameOverText;
    public Text scoreText;
    public Text HighScore;
    public Image FlappyToContinueImg;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

   static int timesDied = 0;

    int Score = 0;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        if(Instance == null)
        
            Instance = this;
        else
            Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
        if(timesDied % 3 == 0 && timesDied > 0)
        {
            if(Advertisement.IsReady())
                Advertisement.Show();
            timesDied = 0;
        }

	}

    public void FlappyScore()
    {
        if (gameOver)
            return;
        Score++;
        scoreText.text = "Score: " + Score.ToString();
    }

    public void Died()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        SetHighScore();
        HighScore.text = "High Score: " + (PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore") : 0);
        timesDied++;
    }

    void SetHighScore()
    {
        int HighScore = 0;
        if(PlayerPrefs.HasKey("HighScore")) {
            HighScore = PlayerPrefs.GetInt("HighScore");
            if (Score > HighScore)
                PlayerPrefs.SetInt("HighScore", Score);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("menu");
        timesDied = 0;
    }

}
