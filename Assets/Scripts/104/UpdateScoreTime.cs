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
    public string scoreText = "Dumb Dumb Score: ";
    private int currentScore = 0;
    public int addScore = 1;
    public int winScore = 5; 

    //Variables for result UI
    private Text resultUI;
     public string resultLost = "You lost!";
    public string resultWin = "You won!";

    // Variables for timer
    private Text timerUI;
    public string timerText = "Jump Jump Time: ";
    public float countRemaining = 10f;
    private bool countingDown = true;

   

    // variables for Game Over
    private bool gameWon;
    private bool gameLost;
    private bool gameOver;

     // variables for enemies
    public int destroyedEnemies;

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
                timerUI.text = timerText + countRemaining.ToString();
                countingDown = false; 
                CheckGameOver();

            }

        }
    }

      public void UpdateScoreEnemyDeath()
    {
        destroyedEnemies++;
        currentScore += addScore;
        scoreUI.text = scoreText + currentScore.ToString();  
        CheckGameOver();
    }
    

    private void CheckGameOver()
    {
        //GameOver WIN
        if(currentScore >= winScore)
        {
            gameWon = true;
            gameOver = true;
       StartCoroutine(GameOver());
        }
        // GameOver LOST
        else if(currentScore < winScore && !countingDown)
        {
            gameLost = true;
            gameOver = true;
            
            StartCoroutine(GameOver());
        }
        }

   


    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);

        if (gameWon)
        {
            resultUI.text = resultWin;
            resultUI.color = Color.green;
        }
        else if (gameLost)
        {
            resultUI.text = resultLost;
            resultUI.color = Color.red;
        }

        _gameUI.SetActive(false);
        _gameOverUI.SetActive(true);

    }
}
