using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HowManyPlayers : MonoBehaviour
{
    //the public value that defines how many players are in the game
    public static int HowManyActivePlayers;

    //the displayed text about how much players are in the game
    public Text HowmuchPlayersTXT;

    //Give the buttons functionality and preset the amount of players that join in on 2
    void Start()
    {
        if (HowManyActivePlayers == 0)
        {
            HowManyActivePlayers = 2;
        }
        HowmuchPlayersTXT.text = HowManyActivePlayers + " Players";
    }


    void OnIncreasePlayerAmount()
    {
        IncreasePlayers();
    }

    void OnDecreasePlayerAmount()
    {
        DecreasePlayers();
    }

    void OnReadyPlayer()
    {
        SceneManager.LoadScene("Minigame");
    }

    //change the displayed txt by adding one player
    void IncreasePlayers()
    {
        if (HowManyActivePlayers < 8)
        {
            HowManyActivePlayers++;
            HowmuchPlayersTXT.text = HowManyActivePlayers + " Players";
        }

    }

    //change to displayed text by substracting one player
    void DecreasePlayers()
    {
        if (HowManyActivePlayers > 2)
        {
            HowManyActivePlayers--;
            HowmuchPlayersTXT.text = HowManyActivePlayers + " Players";
        }
    }
}
