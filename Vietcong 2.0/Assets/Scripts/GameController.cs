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
            //Calls the function StopGame to stop all the hazards.
            StopGame.StopGame();
            //Gets the last player in the list PlayerList and at it in the gameobject variable LastPlayer.
            GameObject LastPlayer = PlayerTotal.PlayerList[0];
            //Disables the name display above the player and the movement and sets the boolean IsRunning to false.
            LastPlayer.GetComponentInChildren<DisplayName>().PlayerNameText.enabled = false;
            LastPlayer.GetComponent<Movement>()._canMove = false;
            LastPlayer.GetComponentInChildren<Animator>().SetBool("IsRunning", false);
            //Adds the last standing player to the ranklist.
            RankPositionPlayer.RankList.Add(LastPlayer);
            //Reverses the list so the rankorder gets displayed from first to last place.
            RankPositionPlayer.RankList.Reverse();
            //Starts the coroutine DelayReset and freezes the time.
            StartCoroutine(DelayReset());                   
        }
    }

    //Before restarting the scene the code waits the amount of seconds before executing ferther that is stored in the float variable DelayResetCount.
    IEnumerator DelayReset()
    {
        yield return new WaitForSecondsRealtime(DelayResetCount);
        //Calls the function DisplayRank to display the Rank order.
        RankOrderScript.DisplayRank();
        yield return new WaitForSecondsRealtime(DelayResetCount);  
    }
}
