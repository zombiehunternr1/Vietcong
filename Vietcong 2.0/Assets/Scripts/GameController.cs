using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    //This function gets called everytime a player gets hit.
    public void ResetGame()
    {
        //Checks if the playerlist is equal to 1.
        if (PlayerTotal.PlayerList.Count == 1)
        {
            //Adds the last standing player to the ranklist.
            RankPosition.AddPlayer(gameObject);
            //Gets the script DisplayRank and stores it in the variable ShowResult.
            var ShowResult = GetComponent<DisplayRank>();
            //Displays the result of the players who came on top.
            ShowResult.RankDisplay();
            //Starts the coroutine DelayReset and freezes the time.
            StartCoroutine(DelayReset());
            Time.timeScale = 0;
        }
    }

    //Before restarting the scene the code waits 2 seconds before executing ferther.
    IEnumerator DelayReset()
    {
        yield return new WaitForSecondsRealtime(2);
        //Unfreezes the time.
        Time.timeScale = 1;
        //Clears the playerlist before reloading the scene.
        PlayerTotal.ResetList();
        //Clears the ranklist before reloading the scene.
        RankPosition.ResetList();
        //Reloads the scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
