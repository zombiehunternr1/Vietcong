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
    //Gets the game controller component that keeps track when the game needs to be reset.
    public GameObject Controller;

    void Awake()
    {
        //Gets  the rigidbody of the projectile.
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
            //Destroys the projectile apon impact and the player and calls the function ResetGame.            
            Destroy(other.gameObject);
            PlayerTotal.PlayerList.Remove(other.gameObject);
            Controller.GetComponent<GameController>().ResetGame();
            Destroy(gameObject);
        }
    }
}

 