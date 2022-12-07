using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WresterlControl : MonoBehaviour
{
    public float horizontalInput;
    public float forwardInput;
    public float speed;
    public float turnSpeed;
    public float force;
    public float forceDown;
    public GameObject Plane; 
    public GameObject Obsticle;
    public float gravityModifier;

    private Animator _playerAnim;
    private Rigidbody _playerRb;
    public bool isJumping;
    public bool isGrounded;
    public bool isFalling;
    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()


    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);
 
    // Ground Test 
       if (isGrounded)
       {
       Debug.Log("Player ist touching the ground"); 
       }   
    // Wrestler is Walkin and Running
        _playerAnim.SetFloat("Run", forwardInput);

        if (forwardInput != 0 || horizontalInput != 0)
        {
            _playerAnim.SetBool("IsMoving", true);
        }
        else
        {
            _playerAnim.SetBool("IsMoving", false);
        }
    // is Jumping  
        if((Input.GetKeyDown(KeyCode.Space)) && (isGrounded))
        {
            isJumping = true;
            isGrounded = false;
            if(isJumping)
            {
             _playerAnim.SetTrigger("Jump");
            }
        }

        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            isJumping = false;
            isFalling = true;
           
            if(isFalling)
            {
                _playerAnim.SetBool("IsFalling",true);

            //_playerAnim.SetBool("IsFalling",true);
            }
           
        }
    
    }
void FixedUpdate()
    {
        if(isJumping)
        {
            _playerRb.AddForce(Vector3.up*force, ForceMode.Force);
            
        }
        if(isFalling || isGrounded)
        {
            _playerRb.AddForce(Vector3.down * forceDown * _playerRb.mass);
        }
        
}
    // // Grond Check for Jump? 
    //  private void OnTriggerEnter(Collider other)
    // {
    //     // When player touches the Ground  
    //     if(other.name == Plane.name)
    //     { 
    //         isGrounded = true; 
    //         Debug.Log("Player ist touching the ground");
    //     }
    //     else 
    //     {
    //         isGrounded = false; 
    //     }
    // } 
    // Collider 
    private void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
          //if(isFalling)
         {
            _playerAnim.SetBool("IsFalling", false);
            isFalling = false; 

            }
          _playerAnim.SetBool("IsGrounded", true);
          isGrounded = true;
        }
       
    }

           
}