using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoal : MonoBehaviour
{
    public GameObject Roboter;
    public AudioSource audioSource;
    public ParticleSystem collisionParticleSystem;
    

   // public GameObject Boom;
    
    
 
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + "just hit" + other.name);

        if(other.name == Roboter.name)
        { 
            // When roboter collides with goal 
            
            audioSource.Play();
            Debug.Log("Victory");
            var em = collisionParticleSystem.emission;
           

            em.enabled = true;
            collisionParticleSystem.Play();

            
            
            
        }
    }
   
}