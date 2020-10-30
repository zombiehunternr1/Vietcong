using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayRankOrder : MonoBehaviour
{
    public void DisplayRank()
    {
        //Make scene black
        //Teleport players to fixed ranked location
        //Make scene visible

        //Resets the Player and Rank list.
        PlayerTotal.ResetList();
        RankPosition.ResetList();

        //Loads in the Start scene.
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
