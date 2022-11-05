using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDecoy : MonoBehaviour
{
 public GameObject Roboter;
 public AudioSource audioSource;
 

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + "just hit" + other.name);

        if(other.name == Roboter.name)
        { 
            // When roboter collides with Decoy 
            Debug.Log("NOOOO!");
            // Teleport cube
            transform.Translate(30,-30,30);

            
            
        }
    }
}
