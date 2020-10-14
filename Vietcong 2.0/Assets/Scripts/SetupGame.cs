using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupGame : MonoBehaviour
{
    private List<Transform> HazardList = new List<Transform>();
    private List<Transform> PlayerList = new List<Transform>();

    public Text CountdownText;

    TileManager TileManagerScript;
    Projectileshooter ProjectileShooterScript;
    Movement PlayerMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        //Adds all the children components from the parent to the array.
        Transform[] TempHazard = GetComponentsInChildren<Transform>();
        Transform[] TempPlayer = GetComponentsInChildren<Transform>();

        //Goes over each item in the variable TempHazard and adds it to the list HazardList.
        foreach (Transform hazard in TempHazard)
        {
            //Checking if any of the items in the array TempHazard has the script TileManager attached to itself, if so add it to the HazardList.
            if (hazard.GetComponent<TileManager>())
            {
                HazardList.Add(hazard);
            }
            //Checking if any of the items in the array TempHazard has the script Projectileshooter attached to itself, if so add it to the HazardList.
            if (hazard.GetComponent<Projectileshooter>())
            {
                HazardList.Add(hazard);
            }
        }
        //Goes over each item in the variable TempPlayer and adds it to the list PlayerList.
        foreach(Transform player in TempPlayer)
        {
            //Checks if any of the items in the array TempPlayer has the script Movement attached to itself, if so add the item to the PlayerList.
            if (player.GetComponent<Movement>())
            {
                PlayerList.Add(player);
            }            
        }
        //Starts the coroutine to setup the game.
        StartCoroutine(PrepareGame());
    }

    //This function gets called to disable all the hazards.
    void DisableHazards()
    {
        //Goes over each item stored in the HazardList.
        foreach (Transform hazard in HazardList)
        {
            //Checks if the item in the HazardList has the TileManager script attached to itself, if so add the item to the variable TileManagerScript and disables the script.
            if (hazard.GetComponent<TileManager>())
            {
                TileManagerScript = hazard.GetComponent<TileManager>();
                TileManagerScript.enabled = false;
            }
            //Checks if the item in the HazardList has the Projectileshooter script attached to itself, if so add the item to the variable ProjectileShooterScript and disables the script.
            if (hazard.GetComponent<Projectileshooter>())
            {
                ProjectileShooterScript = hazard.GetComponent<Projectileshooter>();
                ProjectileShooterScript.enabled = false;
            }
        }
    }
    //This function gets called to disable all the players.
    void DisablePlayers()
    {
        //Goes over each item stored in the list PlayerList and adds the transform in the transform player variable.
        foreach (Transform player in PlayerList)
        {
            //Checks if the item in the PlayerList has the Movement script attched to itself, if so add the item to the variable PlayerMovementScript and disables the script.
            if (player.GetComponent<Movement>())
            {
                PlayerMovementScript = player.GetComponent<Movement>();
                PlayerMovementScript.enabled = false;
            }
        }
    }
    //This function gets called to enable all the hazards.
    void EnableHazards()
    {
        //Goes over each item stored in the HazardList.
        foreach (Transform hazard in HazardList)
        {
            //Checks if the item in the HazardList has the TileManager script attached to itself, if so add the item to the variable TileManagerScript and enables the script.
            if (hazard.GetComponent<TileManager>())
            {
                TileManagerScript = hazard.GetComponent<TileManager>();
                TileManagerScript.enabled = true;
            }
            //Checks if the item in the HazardList has the Projectileshooter script attached to itself, if so add the item to the variable ProjectileShooterScript and enables the script.
            if (hazard.GetComponent<Projectileshooter>())
            {
                ProjectileShooterScript = hazard.GetComponent<Projectileshooter>();
                ProjectileShooterScript.enabled = true;
            }
        }
    }
    //This function gets called to enable all the players.
    void EnablePlayers()
    {
        //Goes over each item stored in the list PlayerList and adds the transform in the transform player variable.
        foreach (Transform player in PlayerList)
        {
            //Checks if the item in the PlayerList has the Movement script attched to itself, if so add the item to the variable PlayerMovementScript and enables the script.
            if (player.GetComponent<Movement>())
            {
                PlayerMovementScript = player.GetComponent<Movement>();
                PlayerMovementScript.enabled = true;
            }
        }
    }

    //This function gets called when the game is going to start.
    public void StartGame()
    {
        EnableHazards();
        EnablePlayers();
    }
    //Disables all the hazards and players. Starts counting down before starting, once it hits "GO!" the function StartGame will be called.
    IEnumerator PrepareGame()
    {
        DisablePlayers();
        DisableHazards();
        CountdownText.text = "3";
        yield return new WaitForSeconds(1);
        CountdownText.text = "2";
        yield return new WaitForSeconds(1);
        CountdownText.text = "1";
        yield return new WaitForSeconds(1);
        CountdownText.text = "Go!";
        StartGame();
        yield return new WaitForSeconds(1);
        CountdownText.text = "";      
    }
}
