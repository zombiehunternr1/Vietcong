using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    public PlayerInfo PlayerInfo;
    private Material PlayerMaterial;
    // Start is called before the first frame update
    void Start()
    {
        //Gets the player color from the scriptable object and places it on the material of the player.
        PlayerMaterial = PlayerInfo.PlayerColor;
        GetComponent<Renderer>().material = PlayerMaterial;
        //Adds player to the totalplayer list if this script is attached to a player.
        PlayerTotal.AddPlayer(gameObject);
    }
}
