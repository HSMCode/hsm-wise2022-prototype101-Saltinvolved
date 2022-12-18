using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveEnemy : MonoBehaviour
{
    // Variabeles for player
 public Transform Player;
 private Rigidbody rig;
 public float speed;
    
  // for score
private GameObject _gameUI;
private Text scoreUI;
public string scoreText = "Score: ";
private int currentScore = 0;
public int addScore = 2;
public int winScore = 6;
    void Start()
    {
        rig = this.GetComponent<Rigidbody>();
        
    scoreUI = GameObject.Find("Score").GetComponent<Text>();
    _gameUI.SetActive(true); 
    }
    void FixedUpdate()
    {
        Vector3 pos=Vector3.MoveTowards(transform.position, Player.position, speed * Time.fixedDeltaTime);
        rig.MovePosition(pos);
        transform.LookAt(Player);
    }
        private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            currentScore += addScore;
            scoreUI.text = scoreText + currentScore.ToString();
             Destroy (gameObject);
        }
    }
 }
