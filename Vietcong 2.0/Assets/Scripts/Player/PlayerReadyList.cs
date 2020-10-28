using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerReadyList : MonoBehaviour
{
    public List<BoolReference> Ready = new List<BoolReference>();
    public SetupGame StartGame;

    int PlayerBool;
    int Count;

    void Awake()
    {
        //Gets all the boolean valuables, converts them into an int and stores them in the variable PlayerBool.
        foreach (BoolReference player in Ready)
        {
            PlayerBool += Convert.ToInt32(player);
        }
    }

    //Function checks if the Count variable is not equal to the PlayerBool variable once a player has readied up. If so that means a player readied up and it ands one to the Count variable.
    //Once the Count variable is equal to the amount of active players it means that all players have readied up and the game will start.
    public void CheckAllPlayersReady()
    {
        if(Count != PlayerBool)
        {
            Count++;

            if (Count == PlayerTotal.PlayerList.Count)
            {
                StartGame.ReadyGame();
            }
        }      
    }
}
