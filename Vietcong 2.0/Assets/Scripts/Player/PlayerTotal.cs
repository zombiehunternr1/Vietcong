using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerTotal
{
    //Creates a statci list that holds all the current active players
    public static List<GameObject> PlayerList = new List<GameObject>();

    //Adds the current active player to the list
    public static void AddPlayer(GameObject go)
    {
        PlayerList.Add(go);
    }
}
