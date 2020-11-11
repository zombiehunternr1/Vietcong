using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHandler : MonoBehaviour
{
    private DisplayName NameDisplay;

    void Awake()
    {
        //Gets the DisplayName component and stores it in the NameDisplay variable.
        NameDisplay = GetComponentInChildren<DisplayName>();
    }

    //This function adds the player to the ranking list and removes it from the player list.
    void AssignRank()
    {
        RankPositionPlayer.RankList.Add(gameObject);
        PlayerTotal.RemovePlayer(gameObject);
    }

    //This function disables the player name and calls the function AssignRank.
    void DisablePlayer()
    {
        NameDisplay.DisableNameDisplay();
        AssignRank();      
    }

    //This function calls the DisablePlayer function once called.
    public void PlayerHit()
    {     
        DisablePlayer();
    }
}
