using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class GameController : MonoBehaviour
{
    public float DelayResetCount;
    public DisplayRankOrder RankOrderScript;
    public SetupGame StopGame;

    void Start()
    {        
        //Stores the amount of active players in the variable ActivePlayers.
        int ActivePlayers = HowManyPlayers.HowManyActivePlayers;

        //Loops over each player object in the playerlist and de-activates the playerobject and disables the name display above the player.
        foreach (var player in PlayerTotal.PlayerList)
        {
            player.SetActive(false);
            player.GetComponentInChildren<DisplayName>().PlayerNameText.enabled = false;    
        }

        //Get all the items in the playerlist and order the gameobjects by name, set them in a list and store this list in the variable SortedList.
        var SortedList = PlayerTotal.PlayerList.OrderBy(go => go.name).ToList();

        //Sets the amount of players active according to the amount of active players that is stored in the variable SortedList.
        //Enables the nameDiplay above the player.
        for (int i = 0; i < ActivePlayers; i++)
        {
            SortedList[i].SetActive(true);
            SortedList[i].GetComponentInChildren<DisplayName>().PlayerNameText.enabled = true;
        }

        //Goes over each playerobject in the list SortedList and checks if this playerobject is false. If so it removes this playerobject from the playerlist.
        foreach(var player in SortedList)
        {
            if (player.activeSelf == false)
            {
                PlayerTotal.PlayerList.Remove(player);
            }
        }
    }

    //This function gets called everytime a player gets hit.
    public void EndGame()
    {
        //Checks if the playerlist is equal to 1.
        if (PlayerTotal.PlayerList.Count == 1)
        {
            //Gets the last player in the list PlayerList and at it in the gameobject variable LastPlayer.
            GameObject LastPlayer = PlayerTotal.PlayerList[0];
            //Adds the last standing player to the ranklist.
            RankPositionPlayer.RankList.Add(LastPlayer);
            //Disables the name display above the player.
            LastPlayer.GetComponentInChildren<DisplayName>().PlayerNameText.enabled = false;
            //Starts the coroutine DelayReset and freezes the time.
            StartCoroutine(DelayReset());
        }
    }

    //Before restarting the scene the code waits the amount of seconds before executing ferther that is stored in the float variable DelayResetCount.
    IEnumerator DelayReset()
    {
        //Calls the function StopGame to stop all the hazards.
        StopGame.StopGame();
        //Calls the function DisplayRank to display the Rank order.
        RankOrderScript.DisplayRank();
        yield return new WaitForSecondsRealtime(DelayResetCount);  
    }
}
