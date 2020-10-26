using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReady : MonoBehaviour
{
    public BoolReference Ready;
    public Text ReadyUI;

    public PlayerReadyList ReadyList;

    //Sets the value to false when starting the game.
    private void Awake()
    {
        Ready.value = false;
    }
    //This function when called sets the ready boolean to true, changes the color from red to green and calls the function "CheckAllPlayersReady".
    private void OnReadyPlayer()
    {
        Ready.value = true;
        ReadyUI.color = Color.green;
        ReadyList.CheckAllPlayersReady();
    }
}
