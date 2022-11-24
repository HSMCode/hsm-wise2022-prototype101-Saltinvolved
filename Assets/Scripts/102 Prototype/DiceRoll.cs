using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
        public int diceNumber;
        public AudioSource audioSource;
        public string message = "It's a Win";
        public int [] luckyNumbers = {22,8,13,50,48,31,32,27};

        public bool lucyNumberWasDrawn;

        public ParticleSystem playParticleSystem;
       

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            diceNumber = Random.Range(1,51);
            // Ausführung mit Array durch forschleife 
            //Debug.Log("You Rolled a " + diceNumber);
            for (int i = 0; i < luckyNumbers.Length; i++)
            {
                //Debug.Log("for loop i" + i);
                if (diceNumber == luckyNumbers[i])
                {
                     PlayParticles(true);
                    audioSource.Play();
                    Debug.Log("<color=green> Lucy Number </color> "+ diceNumber  +" "+ message );
                    lucyNumberWasDrawn= true;
                }
                else if (i == (luckyNumbers.Length-1) && lucyNumberWasDrawn == false)
                { 
                    Debug.Log("<color=red> You Lose </color>"+diceNumber +" is not your lucky number");
                    PlayParticles(false); 
                }
            }
            // reset variable for redraw
            lucyNumberWasDrawn = false; 
        }
    }


void PlayParticles(bool on)
    {
        if(on)
        {
            playParticleSystem.Play();
        }
        else if(!on)
        {
            playParticleSystem.Stop();
        }
    }

 }
