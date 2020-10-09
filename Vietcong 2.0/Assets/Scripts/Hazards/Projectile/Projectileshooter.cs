using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectileshooter : MonoBehaviour
{
    public GameObject Projectile;
    public Transform ProjectileShooterPosition;
    private Color COrange = new Color32(254, 161, 0, 1);
    private float NextFire;
    private float FirstShoot = 5;
    private float SecondShoot = 16;
    private Material PrepToFireColor;
    private Renderer[] PSchilds; 

    // Start is called before the first frame update
    void Start()
    {
        //Gets the material from the projectile.
        PrepToFireColor = GetComponent<Renderer>().material;
        //Gets the renderer component from all the children in the projectileshooter.
        PSchilds = GetComponentsInChildren<Renderer>();

        //Loops over every childcomponent that has a renderer attachted to it in the array PSchilds.
        foreach(Renderer rend in PSchilds)
        {
            //Creat a new variable called mat to store the materials from each child in the array.
            var mat = new Material[rend.materials.Length];
            //Keeps looping until i is no longer smaller then the length of the variable rend.
            for(var i = 0; i < rend.materials.Length; i++)
            {
                //Sets the indivitual material that is stored in the array to the parent material.
                mat[i] = PrepToFireColor;
            }
            //set the child compontent materials to that of the variable mat materials.
            rend.materials = mat;
        }

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

            //Waits the amount of seconds that variable NextFire holds minus 2 before continuing the code.
            yield return new WaitForSeconds(NextFire - 2);
            //Change the projectile shooter to the color orange.
            PrepToFireColor.color = COrange;

            //Waits 1 second before continuing with the code.
            yield return new WaitForSeconds(1);
            //Change the projectile shooter to the color red.
            PrepToFireColor.color = Color.red;

            //Waits 1 second before firing the projectile.
            yield return new WaitForSeconds(1);
            //runs the funtion that creates the projectile.
            ShootProjectile();
            //Changes the color back to white to visually reset the projectileshooter.
            PrepToFireColor.color = Color.white;

            //Returns a null variable so it doesn't effect the framerate and fills up the memory.
            yield return null;         
        }
    }

    void ShootProjectile()
    {
        Instantiate(Projectile, ProjectileShooterPosition.position, ProjectileShooterPosition.rotation);
    }
}
