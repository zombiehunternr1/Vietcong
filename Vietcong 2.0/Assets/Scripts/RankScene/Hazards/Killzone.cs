using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Killzone : MonoBehaviour
{
    public GameEvent KillzoneHit;
    public bool AllowHit = true;
    
    void OnTriggerEnter(Collider other)
    {
        //Checks if its a player that hits the killzone area
        if (PlayerTotal.PlayerList.Contains(other.gameObject))
        {
            //Checks if AllowHit is true. If so it continues executing the rest of the code.
            if (AllowHit)
            {
                //Plays the dying sound effect once the player gets hit.
                other.GetComponent<AudioSource>().Play();
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
                //Sets the boolean IsFlat to false in the animator.
                other.GetComponentInChildren<Animator>().SetBool("IsFlat", false);
                //Checks if the amount of players isn't equal to one else it fires of the events.
                if (PlayerTotal.PlayerList.Count != 1)
                {
                    //Sends an alert to all listening game event listeners.
                    hit.PlayerHit();
                    KillzoneHit.Raise();
                }
            }         
        }
    }
}
