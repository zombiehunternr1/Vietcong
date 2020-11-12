using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float DelayResetCount;
    public DisplayRankOrder RankOrderScript;
    public SetupGame StopGame;
    public Text DisplayerWinnerName;

    private GameObject LastPlayer;

    //This function gets called everytime a player gets hit.
    public void EndGame()
    {
        //Checks if the playerlist is equal to 1.
        if (PlayerTotal.PlayerList.Count == 1)
        {
            //Calls the function StopGame to stop all the hazards.
            StopGame.StopGame();
            //Gets the last player in the list PlayerList and at it in the gameobject variable LastPlayer.
            LastPlayer = PlayerTotal.PlayerList[0];
            //Displays the name of the last player that wins onscreen.
            DisplayerWinnerName.text = "Player " + LastPlayer.GetComponent<PlayerFinder>().PlayerInfo.ID + " Wins!"; 
            //Disables the movement and sets the boolean IsRunning to false.           
            LastPlayer.GetComponentInChildren<Animator>().SetBool("IsRunning", false);
            LastPlayer.GetComponentInChildren<Animator>().SetBool("IsMud", false);
            LastPlayer.GetComponent<Movement>()._canMove = false;
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
        //Disables the display name.
        DisplayerWinnerName.enabled = false;
        //Disables the name display above the last player standing.
        LastPlayer.GetComponentInChildren<DisplayName>().PlayerNameText.enabled = false;
        yield return new WaitForSecondsRealtime(DelayResetCount);  
    }
}
