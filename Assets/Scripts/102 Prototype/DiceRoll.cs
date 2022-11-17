using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
        public int diceNumber;
        public AudioSource audioSource;
        public string message = "It's a Win";
        public int [] luckyNumbers = {22,8,13,50,48,31,32,27};
       

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    async void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            diceNumber = Random.Range(1,51);
            // Ausführung mit Array durch forschleife 
            Debug.Log("You Rolled a " + diceNumber);
            for (int i = 0; i < luckyNumbers.Length; i++)
            {
                Debug.Log("for loop i" + i);
                if (diceNumber == luckyNumbers[i])
                {
                    audioSource.Play();
                    Debug.Log("<color=green> Lucy Number </color> "+ diceNumber  +" "+ message );
                }
                else
                { 
                    Debug.Log("<color=red> You Lose </color>");
                }
            }
     
        }
    
    }

 }