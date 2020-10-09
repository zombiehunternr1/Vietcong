using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    //This function gets called everytime a player gets hit.
    public void ResetGame()
    {
        //Checks if the playerlist is equal to or less then 1.
        if (PlayerTotal.PlayerList.Count <= 1)
        {
            //Clears the list before reloading the scene.
            PlayerTotal.PlayerList.Clear();
            //Reloads the scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
