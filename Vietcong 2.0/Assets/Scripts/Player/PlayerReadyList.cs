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
    private List<Image> Background = new List<Image>();
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

        //Gets all the elements that have the image component attached to them and stores them in the array TempBackground.
        Image[] TempBackground = GetComponentsInChildren<Image>();
        //Gets all the elements that have the Text component attached to them and stores them in the array TempText.
        Text[] TempText = GetComponentsInChildren<Text>();

        //Goes over each text elements in the TempText array and stores them in the list ReadyText that does have the script PlayerReady attached to itself.
        //After that we disable the object.
        foreach (Text PlayerText in TempText)
        {
            if (PlayerText.GetComponent<PlayerReady>())
            {
                ReadyText.Add(PlayerText);
                PlayerText.gameObject.SetActive(false);
            }
        }
        //Goes over each image element and adds it to the list ReadyBackground, afterwards it disables the the object.
        foreach(Image ReadyBackground in TempBackground)
        {
            Background.Add(ReadyBackground);
            ReadyBackground.gameObject.SetActive(false);
        }

        //Get all the items in the ReadyText list and order the gameobjects by name, set them in a list and store this list in the variable SortedPlayers.
        var SortedPlayers = ReadyText.OrderBy(go => go.name).ToList();
        //Get all the items in the ReadyText list and order the gameobjects by name, set them in a list and store this list in the variable SortedBackground.
        var SortedBackground = Background.OrderBy(go => go.name).ToList();

        //Sets the amount of players active according to the amount of active players that is stored in the variable SortedPlayers and SortedBackground.
        //Enables the nameDiplay above the player and the background.
        for (int i = 0; i < ActivePlayers; i++)
        {
            SortedPlayers[i].gameObject.SetActive(true);
            SortedPlayers[i].GetComponentInChildren<PlayerReady>().ReadyUI.enabled = true;
            SortedBackground[i].gameObject.SetActive(true);
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

    //TEST ONLY!! REMOVE AT FINAL BUILD!!
    public void SoloPlay()
    {
        StartGame.ReadyGame();
    }
}
