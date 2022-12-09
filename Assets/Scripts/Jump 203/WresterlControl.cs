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
    public float jumpTimer;
    public float jumpButtonPressTime =2;
    
    private Animator _playerAnim;
    private Rigidbody _playerRb;
   
    public bool jumpCancelled;
    public bool isJumping;
    public bool isGrounded;
    public bool isFalling;
    public bool isLanding;
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
        if((Input.GetKeyDown(KeyCode.Space)) && (isGrounded) && !isFalling)
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
                //_playerAnim.SetBool("IsGrounded",false);
            }

            if(isJumping)
            {
                jumpTimer += Time.deltaTime;
                
                if(Input.GetKeyUp(KeyCode.Space))
                {
                    jumpCancelled =true;

                    isJumping = false;
                    isFalling = true;
                } 
                if(jumpTimer > jumpButtonPressTime)
                {
                    isJumping = false;
                }
            }
            if (_playerRb.velocity.y < 0 && isFalling)
            {
                isLanding = true;
                isFalling = false;
                _playerAnim.SetBool("IsFalling",false); 
            }
            // Backwards 
            if(Input.GetKeyDown(KeyCode.S))
            {
             _playerAnim.SetTrigger("Backwards");
            }

            // // Kick
            // if(Input.GetKeyDown (KeyCode.Q))
            // {
            // _PlayerAnim.SetTrigger("Kick");
            // }
        }
    
    }
void FixedUpdate()
    {
        if(isJumping)
        {
            gravityModifier = 1f;
            _playerRb.AddForce(Vector3.up*force, ForceMode.Force);
            
        }
        if(isFalling || isGrounded || isLanding || jumpCancelled)
        {
           // _playerRb.AddForce(Vector3.down * forceDown * _playerRb.mass);
             gravityModifier = 25f;
        }
        _playerRb.AddForce(Physics.gravity * (gravityModifier -1) * _playerRb.mass);
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
          if(isLanding)
         {
            _playerAnim.SetBool("isLanding", false);
            isLanding = false; 

            }
          _playerAnim.SetBool("IsGrounded", true);
          isGrounded = true;
        }
       
    }
// nicht in Boxen rein 
// private void OnCollisionEnter (Collision collision)
//     {
//         if(collision.gameObject.CompareTag("Block"))
//         {
//           transform.Translate(0,0,-1);
//         }
       
//     }


           
}