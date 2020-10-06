using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectileshooter : MonoBehaviour
{
    public GameObject Projectile;
    public Transform ProjectileShooterPosition;
    private float NextFire;
    private float FirstShoot = 4;
    private float SecondShoot = 8;

    // Start is called before the first frame update
    void Start()
    {
        //Start coroutine to create a projectile and fire it.
       StartCoroutine(CreateProjectile());
    }

    //Coroutine that creates the new projectile.
    IEnumerator CreateProjectile()
    {
        //Keeps looping infinitely
        while(true)
        {
            //Sets the nextfire float based on a random number it generates from the floats FirstShoot and SecondShoot.
            NextFire = Random.Range(FirstShoot, SecondShoot);
            //Delay before firing projectile
            Debug.Log(NextFire);
            yield return new WaitForSeconds(NextFire);    
            //runs the funtion that creates the projectile
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        Instantiate(Projectile, ProjectileShooterPosition.position, ProjectileShooterPosition.rotation);
    }
}
