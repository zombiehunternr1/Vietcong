using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirProjectile : MonoBehaviour
{
    // this is the projectile's speed
    public float PSpeed;
    private Rigidbody Rigid;
    public AudioSource MortarSource;
    public GameObject ExplosionParticle;

    void Awake()
    {
        //Gets the rigidbody of the projectile.
        Rigid = GetComponent<Rigidbody>();
        MortarSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        /*Add force to the rigidbody to move the projectile forward with the PSpeed variable. 
        Since it's falling from the sky the movement needs to go down towards the playarea.*/
        Rigid.AddForce(-Rigid.transform.up * PSpeed);
        
        //Destroys the bullet after the length of the audioclip has been reached.
        Destroy(gameObject, MortarSource.clip.length);
    }

    //Checks if the object collides with another object that has the script Tile attached to itself. If so it gets it's own Meshrenderer component and disables it.
    //Instanciates the explosion effect on the location where the object collided with the object that has the script Tile attached ot itself and stores it in the variable TempExplosionEffect.
    //Then it destroys the effect that is stored in the TempExplosionEffect variable after the duration has finished.
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Tile>())
        {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            var TempExplosionEffect = Instantiate(ExplosionParticle, transform.localPosition + (Vector3.up * 5f), transform.rotation);
            Destroy(TempExplosionEffect, ExplosionParticle.GetComponent<ParticleSystem>().main.duration);
            
        }
    }
}
