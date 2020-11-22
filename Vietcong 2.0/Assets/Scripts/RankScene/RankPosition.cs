using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RankPositionPlayer
{
    //Creates a statci list that holds all the players rank position.
    public static List<GameObject> RankList = new List<GameObject>();

    //Resets the current player list.
    public static void ResetList()
    {
        RankList.Clear();
    }

    //Adds the current active player to the list
    public static void AddPlayer(GameObject go)
    {
        RankList.Add(go);
    }
}
