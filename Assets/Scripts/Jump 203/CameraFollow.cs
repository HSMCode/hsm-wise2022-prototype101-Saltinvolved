using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public Transform target;

    void Start ()
    {
        //target = player.transform;
    }

    
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.LookAt(target);
    }
}
