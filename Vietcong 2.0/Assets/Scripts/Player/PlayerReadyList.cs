using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class PlayerReadyList : MonoBehaviour
{
    public PlayerAssigner Ready;
    public SetupGame StartGame;

    private List<Text> ReadyText = new List<Text>();
    private int ActivePlayers = HowManyPlayers.HowManyActivePlayers;

    int PlayerBool;
    int Count;

    private AudioClip PlayerReady;
    private AudioSource ReadySource;

    void Awake()
    {
        //Gets the audio source and stores the clip in the variable PlayerReady;
        ReadySource = GetComponent<AudioSource>();
        PlayerReady = ReadySource.clip;

        Text[] TempText = GetComponentsInChildren<Text>();

        //Gets all the text elements and stores them in the list ReadyText that doesn't have the script PlayerReady attached to itself.
        //After that we disable the object.
        foreach (Text PlayerText in TempText)
        {
            if (!PlayerText.GetComponent<PlayerReady>())
            {
                ReadyText.Add(PlayerText);
                PlayerText.gameObject.SetActive(false);
            }
        }

        //Get all the items in the ReadyText list and order the gameobjects by name, set them in a list and store this list in the variable SortedList.
        var SortedList = ReadyText.OrderBy(go => go.name).ToList();

        //Sets the amount of players active according to the amount of active players that is stored in the variable SortedList.
        //Enables the nameDiplay above the player.
        for (int i = 0; i < ActivePlayers; i++)
        {
            SortedList[i].gameObject.SetActive(true);
            SortedList[i].GetComponentInChildren<PlayerReady>().ReadyUI.enabled = true;
        }
    }

    public void AddBool()
    {
        //Gets all the boolean valuables, converts them into an int and stores them in the variable PlayerBool.
        foreach (BoolReference player in Ready._BoolReferenceList)
        {
            PlayerBool += Convert.ToInt32(player);
        }
    }

    //Function plays the player ready sound effect and checks if the Count variable is not equal to the PlayerBool variable once a player has readied up. 
    //If so that means a player readied up and it ands one to the Count variable.
    //Once the Count variable is equal to the amount of active players it means that all players have readied up and the game will start.
    public void CheckAllPlayersReady()
    {
        ReadySource.PlayOneShot(PlayerReady, 0.7f);
        if (Count != PlayerBool)
        {
            Count++;

            if (Count == PlayerTotal.PlayerList.Count)
            {
                StartGame.ReadyGame();
            }
        }      
    }
}
