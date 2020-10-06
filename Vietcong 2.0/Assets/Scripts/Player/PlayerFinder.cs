using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Adds player to the totalplayer list if this script is attached to a player.
        PlayerTotal.AddPlayer(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
