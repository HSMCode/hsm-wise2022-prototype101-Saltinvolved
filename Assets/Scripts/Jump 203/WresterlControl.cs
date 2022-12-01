using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WresterlControl : MonoBehaviour
{
    public float horizontalInput;
    public float forwardInput;
    public float speed;
    public float turnSpeed;
    public Vector3 force;
    public GameObject Plane; 

    private Animator _playerAnim;
    private Rigidbody _playerRb;
    //private bool isJumping;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);
 
        // Versuch eine Rennen zu instalieren 
        // if (Input.GetKeyDown(KeyCode))
        //  {
        //     speed = 5;
        //  }
        //  else 
        //  {
        //     speed = 0.5;
        //  }

         // versuch ende 

        _playerAnim.SetFloat("Run", forwardInput);

        if (forwardInput != 0 || horizontalInput != 0)
        {
            _playerAnim.SetBool("IsMoving", true);
        }
        else
        {
            _playerAnim.SetBool("IsMoving", false);
        }

        if((Input.GetKeyDown(KeyCode.Space)) && (isGrounded))
        {
            _playerRb.AddForce(force, ForceMode.Impulse);
            _playerAnim.SetTrigger("IsJumping");
        }
    }

    // Grond Check for Jump? 
     private void OnTriggerEnter(Collider other)
    {

         // When player touches the Ground  
        if(other.name == Plane.name)
        { 
            isGrounded = true; 
            Debug.Log("Player ist touching the ground");
        }
        else 
        {
            isGrounded = false; 
        }
    }        
}