using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public float DelayResetCount;
    
    //This function gets called everytime a player gets hit.
    public void EndGame()
    {
        //Checks if the playerlist is equal to 1.
        if (PlayerTotal.PlayerList.Count == 1)
        {
            //Gets the last player in the list PlayerList and at it in the gameobject variable LastPlayer.
            GameObject LastPlayer = PlayerTotal.PlayerList[0];
            //Adds the last standing player to the ranklist.
            RankPosition.RankList.Add(LastPlayer);
            //Gets the script DisplayRank and stores it in the variable ShowResult.
            var ShowResult = GetComponent<DisplayRank>();
            //Displays the result of the players who came on top.
            ShowResult.RankDisplay();
            //Starts the coroutine DelayReset and freezes the time.
            StartCoroutine(DelayReset());
            Time.timeScale = 0;
        }
    }

    //Before restarting the scene the code waits the amount of seconds before executing ferther that is stored in the float variable DelayResetCount.
    IEnumerator DelayReset()
    {
        yield return new WaitForSecondsRealtime(DelayResetCount);
        //Unfreezes the time.
        Time.timeScale = 1;
        //Clears the playerlist before reloading the scene.
        PlayerTotal.ResetList();
        //Clears the ranklist before reloading the scene.
        RankPosition.ResetList();
        //Loads in the Ranking scene.
        SceneManager.LoadScene("Ranking", LoadSceneMode.Single);
    }
}
