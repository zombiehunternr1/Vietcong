using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerReady : MonoBehaviour
{
    public BoolReference Ready;
    public Text ReadyUI;

    public PlayerReadyList ReadyList;

    private bool RediedUp;

    private PlayerInput Input;

    //Gets the playerInput component and stores it in the PlayerInput variable Input.
    private void Awake()
    {
        Input = GetComponent<PlayerInput>();
    }

    //This function when called it checks if the boolean RediedUp isn't true yet, if so it sets the RediedUp and Ready boolean to true, changes the color from red to green and changes the action map from UI to Minigame.
    //At last it calls the function "CheckAllPlayersReady".
    private void OnReadyPlayer()
    {
        if (!RediedUp)
        {
            RediedUp = true;
            Ready.value = true;
            ReadyUI.color = Color.green;
            Input.SwitchCurrentActionMap("Minigame");
            ReadyList.CheckAllPlayersReady();     
        }
    }


    //TESTING ONLY!!! REMOVE AT FINAL RELEASE!!!
    private void OnTest()
    {
        Input.SwitchCurrentActionMap("Minigame");
        ReadyList.SoloPlay();
    }
}
