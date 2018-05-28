using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCode : MonoBehaviour {

    Text HighScoreText;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Use this for initialization
    void Start () {
        HighScoreText = transform.Find("HighScore").GetComponent<Text>();
        if (PlayerPrefs.HasKey("HighScore"))
            HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        else
            PlayerPrefs.SetInt("HighScore", 0);
	}

    public void StartGame()
    {
        SceneManager.LoadScene("game");
    }
}
