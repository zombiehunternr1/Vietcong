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
    private PlayerInputControls PlayerInput;

    //Sets the value to false when starting the game.
    private void Awake()
    {
        PlayerInput = new PlayerInputControls();
        Ready.value = false;
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
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
            ReadyList.CheckAllPlayersReady();          
        }
    }
}
