using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roboter : MonoBehaviour
{
    
     public float step = 1f;
     public float turn = 90f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //movement on the Z-axis 
    
    // Move roboter back relative to Map 
    if(Input.GetKeyDown("w"))
    transform.Translate(0,0,step,Space.World);

    // Move roboter forward
    if(Input.GetKeyDown("s"))
    transform.Translate(0,0,-step,Space.World);
    
    //Move roboter left
    if(Input.GetKeyDown("a"))
    transform.Translate(-step,0,0,Space.World);

    //move roboter right
    if(Input.GetKeyDown("d"))
    transform.Translate(step,0,0,Space.World);

    //rotate on the y-axis
     //rotate roboter left 
    if(Input.GetKeyDown("q"))
    transform.Rotate(0,-turn,0,Space.World);
   

    //rotate roboter right 
    if(Input.GetKeyDown("e"))
    transform.Rotate(0,turn,0,Space.World);


    }   
    
}

