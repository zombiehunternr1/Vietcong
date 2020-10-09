using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    //Gets the game controller component that keeps track when the game needs to be reset.
    public GameObject Controller;

    void OnTriggerEnter(Collider other)
    {
        //Checks if its a player that hits the killzone area
        if (PlayerTotal.PlayerList.Contains(other.gameObject))
        {
            //Destroys the player and calles the function ResetGame.
            PlayerTotal.PlayerList.Remove(other.gameObject);
            Controller.GetComponent<GameController>().ResetGame();
            Destroy(other.gameObject);
        }
        
    }
}
