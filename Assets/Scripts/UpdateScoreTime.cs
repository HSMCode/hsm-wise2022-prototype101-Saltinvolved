using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreTime : MonoBehaviour
{
    private GameObject _gameUI;
    private GameObject _gameOverUI;

    //variables for Score
    private Text scoreUI;
    public string scoreText = "Punktestand: ";
    private int currentScore = 0;
    public int addScore = 1;
    public int winScore = 5; 

    // Variables for timer
    private Text timerUI;
    public string timerText = "Countdown: ";
    public float countRemaining = 10f;
    private bool countingDown = true;

    // variables for ui 
    private Text resultUI;
    public string resultLost = "you lost! ";
    public string resultWon = "you won! ";

    // variables for Game Over
    private bool gameWon;
    private bool gameLost;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        _gameUI = GameObject.Find("Game");
        _gameOverUI = GameObject.Find("GameOver");


        scoreUI = GameObject.Find("Score").GetComponent<Text>();
        timerUI = GameObject.Find("Timer").GetComponent<Text>();
        resultUI = GameObject.Find("Result").GetComponent<Text>();

        _gameUI.SetActive(true);
        _gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CountdownTimer();

        if(Input.GetKeyDown(KeyCode.Space))

        {
            currentScore += addScore;
            scoreUI.text = scoreText + currentScore.ToString(); 
        }
    }
     private void CountdownTimer()
    {
        if(countingDown)
        {
            if(countRemaining > 0)
            {
                countRemaining -= Time.deltaTime;
                timerUI.text = timerText + Mathf.Round(countRemaining).ToString();
                
            }
            else
            {
                countRemaining = 0;
                timerUI.text = timerText + countRemaining;
                countingDown = false; 
                CheckGameOver();

            }

        }
    }

    private void CheckGameOver()
    {
        //GameOver WIN
        if(currentScore >= winScore)
        {
            gameWon = true;
            gameOver = true;

            resultUI.text = resultWin;
            resultUI.color = Color.green;
           
        }
        //GameOver LOST

        else if (currentScore < winScore && !countingDown)
        {
            gameLost = true;
            gameOver = true;
            resultUI.text = resultLost;
            resultUI.color = Color.red;

           
        }
        if (gameOver)
        {
             _gameUI.SetActive(false);
            _gameOverUI.SetActive(false);
        }
    }

   
}
