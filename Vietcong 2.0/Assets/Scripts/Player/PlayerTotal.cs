using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerTotal
{
    //Creates a statci list that holds all the current active players
    public static List<GameObject> PlayerList = new List<GameObject>();

    //Resets the current player list.
    public static void ResetList()
    {
        PlayerList.Clear();
    }

    //Removes player from the playe list.
    public static void RemovePlayer(GameObject go)
    {
        PlayerList.Remove(go);
    }

    //Adds the current active player to the list
    public static void AddPlayer(GameObject go)
    {
        PlayerList.Add(go);
    }
}
