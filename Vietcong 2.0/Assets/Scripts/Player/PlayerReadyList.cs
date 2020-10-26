using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReadyList : MonoBehaviour
{
    public List<BoolReference> Ready = new List<BoolReference>();
    public SetupGame StartGame;
    public Text StartGameText;

    //Function checks if all players are ready, if so it starts the game.
    public void CheckAllPlayersReady()
    {
        if (Ready.Count == PlayerTotal.PlayerList.Count)
        {
            StartGameText.color = Color.green;
            //StartGame.ReadyGame();
        }      
    }
}
