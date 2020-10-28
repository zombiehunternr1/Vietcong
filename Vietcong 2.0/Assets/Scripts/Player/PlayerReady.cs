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

    //Sets the value to false when starting the game.
    private void Awake()
    {
        Ready.value = false;
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
}
