using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirProjectile : MonoBehaviour
{
    // this is the projectile's speed
    public float PSpeed;
    // this is the projectile's lifespan (in seconds)
    public float PLifespan = 10f;
    private Rigidbody Rigid;

    void Awake()
    {
        //Gets the rigidbody of the projectile.
        Rigid = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        /*Add force to the rigidbody to move the projectile forward with the PSpeed variable. 
        Since it's falling from the sky the movement needs to go down towards the playarea.*/
        Rigid.AddForce(-Rigid.transform.up * PSpeed);
        //Destroys the bullet after the life span of the projectile has been reached.
        Destroy(gameObject, PLifespan);
    }
}
