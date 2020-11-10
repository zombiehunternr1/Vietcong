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
            //Reverses the list so the rankorder gets displayed from first to last place.
            RankPositionPlayer.RankList.Reverse();
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
