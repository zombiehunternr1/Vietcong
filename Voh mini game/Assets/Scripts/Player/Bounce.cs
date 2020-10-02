using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float force;
    public Rigidbody rb;
    Vector3 pushDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    { 
        if(col.collider.name == "Player")
        {
            pushDirection = rb.transform.position - col.transform.position;
            rb.AddForce(pushDirection.normalized * force);
        }       
    }
}
