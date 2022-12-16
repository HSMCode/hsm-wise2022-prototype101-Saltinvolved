using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    // Start is called before the first frame update
 public Transform Player;
 private Rigidbody rig;
 public float speed;
    

    void Start()
    {
        rig = this.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 pos=Vector3.MoveTowards(transform.position, Player.position, speed * Time.fixedDeltaTime);
        rig.MovePosition(pos);
        transform.LookAt(Player);
    }
 }
