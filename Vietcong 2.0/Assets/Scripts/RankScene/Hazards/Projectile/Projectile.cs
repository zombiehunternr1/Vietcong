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

    private AudioClip PlayDying;
    public AudioSource DyingSource;

    void Awake()
    {
        //Gets the rigidbody of the projectile.
        Rigid = GetComponent<Rigidbody>();
        //Gets the clip from the audio source DyingSource and stores it in the variable PlayDying.
        PlayDying = DyingSource.clip;
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
        //Checks if the projectile hits a player. If so it plays the dying sound effect and disables the object if the sound effect isn't playing anymore.
        if (PlayerTotal.PlayerList.Contains(other.gameObject))
        {
            DyingSource.PlayOneShot(PlayDying, 0.7f);
            if (!DyingSource.isPlaying)
            {
                gameObject.SetActive(false);
            }            
        }
    }
}

 