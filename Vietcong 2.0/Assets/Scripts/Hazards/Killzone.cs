using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //Checks if its a player that hits the killzone area
        if (PlayerTotal.PlayerList.Contains(other.gameObject))
        {
            //Destroys the player
            Destroy(other.gameObject);
        }
    }
}
