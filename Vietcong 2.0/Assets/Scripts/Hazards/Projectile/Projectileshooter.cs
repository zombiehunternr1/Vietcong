using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectileshooter : MonoBehaviour
{
    public GameObject Projectile;
    public Transform ProjectileShooterPosition;
    public bool CanFire = false;
    private float NextFire;
    private float FirstShoot = 5;
    private float SecondShoot = 16;
    private Animator[] AnimControllers;

    // Start is called before the first frame update
    void Start()
    {
        //Gets all the animator controller in the children objects and stores them in the variable array AnimControllers.
        AnimControllers = GetComponentsInChildren<Animator>();

        //Starts the coroutine CreateProjectile.
        StartCoroutine(CreateProjectile());
    }

    //Coroutine that creates the new projectile.
    public IEnumerator CreateProjectile()
    {
        //Keeps looping infinitely
        while (true)
        {
            //Checks if the boolean CanFire is true. If so it continues executing the rest of the code. If not it returns null.
            if (CanFire)
            {
                //Sets the nextfire float based on a random number it generates from the floats FirstShoot and SecondShoot.
                NextFire = UnityEngine.Random.Range(FirstShoot, SecondShoot);

                //Waits the amount of seconds that variable NextFire holds minus 2 before continuing the code.
                yield return new WaitForSeconds(NextFire - 2);

                //Goes over each AnimController in the array AnimControllers.
                foreach (Animator AnimController in AnimControllers)
                {
                    //Resets the Idle trigger and sets the TakeAim trigger.
                    AnimController.ResetTrigger("Idle");
                    AnimController.SetTrigger("TakeAim");
                }

                //Waits 1 second before continuing with the code.
                yield return new WaitForSeconds(1);

                //Goes over each AnimController in the array AnimControllers.
                foreach (Animator AnimController in AnimControllers)
                {
                    //Resets the TakeAim trigger and sets the fire trigger
                    AnimController.ResetTrigger("TakeAim");
                    AnimController.SetTrigger("Fire");
                }
                //runs the funtion that creates the projectile.
                ShootProjectile();

                //Waits half a second before firing the projectile.
                yield return new WaitForSeconds(0.5f);

                //Goes over each AnimController in the array AnimControllers.
                foreach (Animator AnimController in AnimControllers)
                {
                    //Resets the fire trigger and sets the reload trigger.
                    AnimController.ResetTrigger("Fire");
                    AnimController.SetTrigger("Reload");
                }

                //Waits 2.5 seconds before continuing the code.
                yield return new WaitForSeconds(2.5f);

                //Goes over each AnimController in the array AnimControllers.
                foreach (Animator AnimController in AnimControllers)
                {
                    //Resets the Reload trigger and sets the Idle trigger.
                    AnimController.ResetTrigger("Reload");
                    AnimController.SetTrigger("Idle");
                }
            }
            yield return null;
        }     
    }

    void ShootProjectile()
    {
        Instantiate(Projectile, ProjectileShooterPosition.position + (Vector3.up * 2f), ProjectileShooterPosition.rotation);
    }
}
