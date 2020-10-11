using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // this is the projectile's speed
    public float PSpeed;
    // this is the projectile's lifespan (in seconds)
    public float PLifespan = 60f; 
    private Rigidbody Rigid;
    public GameEvent ProjectileHit;

    void Awake()
    {
        //Gets the rigidbody of the projectile.
        Rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        /*Add force to the rigidbody to move the projectile forward with the PSpeed variable. 
        Because it needs to shoot out of the cilider I need to use the transform.up position because of the cilider is positioned */
        Rigid.AddForce(Rigid.transform.up * PSpeed);
        //Destroys the bullet after the life span of the projectile has been reached.
        Destroy(gameObject, PLifespan);
    }

    void OnTriggerEnter(Collider other)
    {
        //Checks if the projectile hits a player.
        if (PlayerTotal.PlayerList.Contains(other.gameObject))
        {           
            //Destroys the projectile apon impact and the player, removes the player from the playerlist and adds player to the ranklist then calls the game event listener.         
            Destroy(other.gameObject);
            RankPosition.AddPlayer(other.gameObject);
            PlayerTotal.RemovePlayer(other.gameObject);
            //Sends an alert to all listening game event listeners.
            ProjectileHit.Raise();                
            Destroy(gameObject);
        }
    }
}

 