﻿using System.Collections;
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
            //Sets the _canMove boolean to false so the player can't move around while or after dying.
            other.GetComponent<Movement>()._canMove = false;
            //Disables the bounce script so the remaining players can't collide with the dead player.
            other.GetComponentInChildren<Bounce>().enabled = false;
            //Sets the boolean IsRunning to false in the Animator.
            other.GetComponentInChildren<Animator>().SetBool("IsRunning", false);
            //Sets the boolean Died to true in the animator.
            other.GetComponentInChildren<Animator>().SetBool("Died", true);
            //Sends an alert to all listening game event listeners.
            hit.PlayerHit();
            KillzoneHit.Raise();
        }
    }
}
