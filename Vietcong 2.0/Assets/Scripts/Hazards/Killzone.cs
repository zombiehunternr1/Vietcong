using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Killzone : MonoBehaviour
{
    public GameEvent KillzoneHit;
    
    void OnTriggerEnter(Collider other)
    {
        //Checks if its a player that hits the killzone area
        if (PlayerTotal.PlayerList.Contains(other.gameObject))
        {
            //Gets the component Hit Handler and stores it in the variable hit.
            HitHandler hit = other.GetComponent<HitHandler>();

            //Sends an alert to all listening game event listeners.
            hit.PlayerHit();
            KillzoneHit.Raise();
        }
    }
}
