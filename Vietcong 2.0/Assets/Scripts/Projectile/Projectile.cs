using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // this is the projectile's speed
    public float PSpeed = 20f;
    // this is the projectile's lifespan (in seconds)
    public float PLifespan = 60f; 
    private Rigidbody Rigid;

    void Awake()
    {
        //Gets  the rigidbody of the projectile.
        Rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //Add force to the rigidbody to move the projectile forward with the PSpeed variable.
        Rigid.AddForce(Rigid.transform.forward * PSpeed);
        //Destroys the bullet after the life span of the projectile has been reached.
        Destroy(gameObject, PLifespan);
    }

    void OnTriggerEnter(Collider other)
    {
        //Checks if the projectile hits a player.
        if (PlayerTotal.PlayerList.Contains(other.gameObject))
        {
            //Destroys the projectile apon impact and the player.
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}

 