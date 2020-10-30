using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Linq;

public class GameController : MonoBehaviour
{
    public float DelayResetCount;

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
        //Loads in the Ranking scene.
        SceneManager.LoadScene("Ranking", LoadSceneMode.Single);
    }
}
