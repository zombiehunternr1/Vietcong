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
        RankPosition.RankList.Add(gameObject);
        PlayerTotal.RemovePlayer(gameObject);
    }

    //This function disables the player.
    void DisablePlayer()
    {
        gameObject.SetActive(false);
    }
    //This function disables the text displayed above the player.
    void DisableName()
    { 
        NameDisplay.DisableNameDisplay();
    }
    //This function execute the function above in a certain order.
    public void PlayerHit()
    {
        AssignRank();
        DisableName();
        DisablePlayer();
    }
}
