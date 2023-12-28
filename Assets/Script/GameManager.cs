using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject ball, resButton, exButton, highScoreText, scoreText;

    int score, highScore;

    public int multiplier;


    /*public Text highScoreText;
    public Text scoreText;
    public Button resButton;
    public Button exButton;*/


    public static GameManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Time.timeScale = 1;
        score = 0;
        multiplier = 1;
        highScore = PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore") : 0;
        highScoreText.GetComponent<Text>().text = "HighScore : " + highScore;
    }

    private void Start()
    {
        
    }


    // Update is called once per frame
    private void Update()
    {

    }

    public void UpdateScore(int point,int nullIncrease)
    {
        multiplier += nullIncrease;
        score += point * multiplier;
        scoreText.GetComponent<Text>().text = "Score : " + score;
    }

    public void GameEnd()
    {
        Time.timeScale = 0;

        resButton.SetActive(true);
        exButton.SetActive(true);
        highScoreText.SetActive(true);

        if(score > highScore) 
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;
        }
        highScoreText.GetComponent<Text>().text = "HighScore : " + highScore;
    }

    public void GameStart() 
    {
        highScoreText.SetActive(false);
        scoreText.SetActive(true);
    }

    public void GameRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
