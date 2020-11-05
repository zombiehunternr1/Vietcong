using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class HowManyPlayers : MonoBehaviour
{
    public RectTransform FadeToBlackPanel;
    private int FadingSpeed = 1;

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

    private AudioClip SelectPlayerAmountSound;
    public AudioSource SelectSource;

    private AudioClip StartSound;
    public AudioSource StartSource;

    private bool IsPlayed = false;
    private bool FadedToBlack;

    //Give the buttons functionality and preset the amount of players that join in on 2
    void Start()
    {
        //Gets the audio clip from the audio source and stores it in the variable SelectPlayerAmountSound.
        SelectPlayerAmountSound = SelectSource.clip;
        //Gets the audio source component and stores it in the variable StartSource.
        StartSound = StartSource.clip;

        //Checks if the int HowManyActivePlayers is 0. If that is true it sets it to 2 and displays it on the screen.
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
                //Calls the function to increase the player amount, plays the soundeffect and sets the bool AllowInput to false;
                SelectSource.PlayOneShot(SelectPlayerAmountSound, 0.7f);
                OnDecreasePlayerAmount();
                AllowInput = false;
            }
            //Checks if the right D-Pad has been pressed.
            if (DPadInput.right)
            {
                //Calls the function to decrease the player amount, plays the soundeffect and sets the bool AllowInput to false;
                SelectSource.PlayOneShot(SelectPlayerAmountSound, 0.7f);
                OnIncreasePlayerAmount();
                AllowInput = false;
            }
        }
        //Checks if the value DelayAllowInput is smaller then 0.1. If that is true it means the Delay is over and the player is allowed to press the D-Pad buttons again.
        //The bool AllowInput will be set to true.
        if (DelayAllowInput < 0.1)
        {
            AllowInput = true;
        }
        //Checks if the south button of a gamepad is pressed.
        if (Gamepad.current.buttonSouth.isPressed)
        {
            //Checks if the bool IsPlayed is false. If so it plays the sound effect and sets the bool to true.
            if (!IsPlayed)
            {
                StartSource.PlayOneShot(StartSound, 0.7f);
                IsPlayed = true;
            }
            //Sets the bool FadedToBlack to true and starts the Coroutine FadeToBlack.
            FadedToBlack = true;
            StartCoroutine(FadeToBlack());
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

    //This coroutine switches the panel from opaque to black. If it's black it calls the function OnReadyPlayer.
    IEnumerator FadeToBlack()
    {
        //Gets the color component from the panel and stores it in the FadingColor variable.
        Color FadingColor = FadeToBlackPanel.GetComponent<Image>().color;
        float FadeAmount;
        if (FadedToBlack)
        {
            //Keeps looping until the alpha color of the image isn't smaller then 1.
            while (FadeToBlackPanel.GetComponent<Image>().color.a < 1)
            {
                FadeAmount = FadingColor.a + (FadingSpeed * Time.deltaTime);
                FadingColor = new Color(FadingColor.r, FadingColor.g, FadingColor.g, FadeAmount);
                FadeToBlackPanel.GetComponent<Image>().color = FadingColor;
                yield return null;
            }
            yield return new WaitForSeconds(FadingSpeed);
            FadedToBlack = false;
            StartCoroutine(FadeToBlack());
        }
        else
        {
            //Checks if the alpha color of the image is greater or equal to 1. If so it means the screen is completely black and we can call the function OnReadyPlayer.
            if (FadeToBlackPanel.GetComponent<Image>().color.a >= 1)
            {
                OnReadyPlayer();
            }
        }       
    }
}
