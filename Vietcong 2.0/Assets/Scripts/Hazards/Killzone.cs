using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    public GameEvent KillzoneHit;

    void OnTriggerEnter(Collider other)
    {
        //Checks if its a player that hits the killzone area
        if (PlayerTotal.PlayerList.Contains(other.gameObject))
        {
            //Destroys the killzone and the player gets disabled. Removes the player from the playerlist and adds player to the ranklist then calls the game event listener.
            PlayerTotal.RemovePlayer(other.gameObject);
            RankPosition.RankList.Insert(0, other.gameObject);
            //Sends an alert to all listening game event listeners.
            KillzoneHit.Raise();
            other.gameObject.SetActive(false);
        }      
    }
}
