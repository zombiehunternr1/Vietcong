using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class HowManyPlayers : MonoBehaviour
{
    //the public value that defines how many players are in the game
    public static int HowManyActivePlayers;
    //the displayed text about how much players are in the game
    public Text HowmuchPlayersTXT;

    private bool AllowInput = true;
    private float StartTime = 0;
    private float WaitTime = 3;

    private float StartAllowInput = 0;
    private float EndAllowInput = 0.2f;
    private float Duration = 0.2f;
    private float timer = 0;

    //Give the buttons functionality and preset the amount of players that join in on 2
    void Start()
    {
        if (HowManyActivePlayers == 0)
        {
            HowManyActivePlayers = 2;
        }
        HowmuchPlayersTXT.text = HowManyActivePlayers + " Players";
    }

    void Update()
    {
        //Increases the timer variable over realtime has passed.
        timer += Time.deltaTime;
        //Slowly increases and decreases the value once it hit either the StartTime value or the WaitTime value.
        //This value will be stored in the float DelayAllowInput.
        float DelayAllowInput = Mathf.Lerp(StartTime, WaitTime, Mathf.PingPong(timer, Duration) / Duration);

        //Checks if the bool AllowInput is true and if value output between DelayAllowInput minus StartAllowInput is greater then the value EndAllowInput.
        if (AllowInput && DelayAllowInput - StartAllowInput > EndAllowInput)
        {
            //Checks if the left D-Pad has been pressed.
            if (DPadInput.left)
            {
                //Calls the function to increase the player amount and sets the bool AllowInput to false;
                OnDecreasePlayerAmount();
                AllowInput = false;
            }
            //Checks if the right D-Pad has been pressed.
            if (DPadInput.right)
            {
                //Calls the function to decrease the player amount and sets the bool AllowInput to false;
                OnIncreasePlayerAmount();
                AllowInput = false;
            }
        }
        //Checks if the value DelayAllowInput is smaller then 0.1. If that is true it means the Delay is over and the player is allowed to press the D-Pad buttons again.
        //The bool AllowInput will be set to true.
        if(DelayAllowInput < 0.1)
        {
            AllowInput = true;
        }
        //Checks if the south button of a gamepad is pressed. If so it calls the function OnReadyPlayer.
        if (Gamepad.current.buttonSouth.isPressed)
        {
            OnReadyPlayer();
        }
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
