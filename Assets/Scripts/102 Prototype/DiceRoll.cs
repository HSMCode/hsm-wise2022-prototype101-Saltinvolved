using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
        public int diceNumber;
        public AudioSource audioSource;
        public string message = "It's a Win";
        
        public int lucyNumber5 = 5;
        public int lucyNumber1 = 1;
        public int lucyNumber4 = 4;

    
       

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            diceNumber = Random.Range(1,7);
            Debug.Log("You rolled number: " + diceNumber);
            
            // Ausführung durch Oder zeichen in If statement 

            if (diceNumber == lucyNumber1 || diceNumber == lucyNumber5 || diceNumber == lucyNumber4)
            {
                 audioSource.Play();
                Debug.Log("<color=green> Lucy Number </color> "+ diceNumber  +" "+ message );
            }
            else 
            {
            Debug.Log("<color=red> You Lose </color>");
            }
        //     // Lucy Number 5
        //     if (diceNumber == 5) 
        //     {
        //         audioSource.Play();
        //         Debug.Log( "<color=red> Lucy Number </color> "+ diceNumber  +" "+ message );
        //     }
        //     // Lucy Number 1
        //     if (diceNumber == 1) 
        //     {
        //         audioSource.Play();
        //         Debug.Log( "<color=green> Lucy Number </color> "+ diceNumber  +" "+ message );
        //     }
        //     // Lucy Number 4 
        //       if (diceNumber == 4) 
        //     {
        //         audioSource.Play();
        //         Debug.Log( "<color=blue> Lucy Number </color> "+ diceNumber  +" "+ message );
        //     }
        // 
        }
    
    }

 }
