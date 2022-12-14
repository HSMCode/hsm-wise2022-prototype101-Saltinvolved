using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTestCode : MonoBehaviour
{
   public float horizontalInput;
    public float forwardInput;
    public float speed;
    public float turnSpeed;
    public Vector3 force;
    public GameObject Plane; 

    private Animator _playerAnim;
    private Rigidbody _playerRb;
   private bool isJumping = false;
   //private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        //_playerAnim = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);

        //_playerAnim.SetFloat("Run", forwardInput);

        if (forwardInput !=0 || horizontalInput !=0)
        {
            // _playerAnim.SetBool("isMoving", true);
         }
        else
        {
            // _playerAnim.SetBool("isMoving", false);
         }

        if(Input.GetKeyDown(KeyCode.Space)  && !isJumping)
        { 
           // _playerRb.AddForce(force, ForceMode.Impulse);
           // _playerAnim.SetTrigger("isJumpingt");
            //_playerAnim.SetBool("isJumping",true);
            isJumping = true;
            //isGrounded = false; 
        }
        //else 
        //{
            //_playerAnim.SetTrigger("isJumping",false);
        //}
    }

   // Ground Check for Jump? 
     private void OnTriggerEnter(Collider other)
    {

         // When player touches the Ground  
        if(other.name == Plane.name)
        { 
          isJumping = false;  
            Debug.Log("Player ist touching the ground");
        }
        else 
        {
            isJumping= true; 
        }
    }   

    // Ground check with Collider

//    private void OnCollisionEnter (Collision collision)
//      {
//          isGrounded = true; 
//         Debug.Log("Player ist touching the ground");

//      }     
}

