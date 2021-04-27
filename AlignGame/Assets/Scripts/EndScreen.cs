using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class EndScreen : MonoBehaviour
{
    ScoreCounter scoreCounter;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = GameObject.Find("MainCanvas").transform.GetChild(3).transform.GetChild(0).GetComponent<ScoreCounter>();
        scoreText.text = scoreCounter.GetTextMeshProUGUI().text;
        Int32 score = Int32.Parse(scoreCounter.GetTextMeshProUGUI().text);
        //print("Before " + PlayerPrefs.GetInt("HighScore", 0).ToString());
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            print("After " + PlayerPrefs.GetInt("HighScore", 0).ToString());
            highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        } else
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Don't use this
    public void Quit()
    {
          Application.Quit();  
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        PauseScript.gamePaused = false;
        scoreCounter.setText("0");
        SceneManager.LoadScene("Level1");
    }
}
