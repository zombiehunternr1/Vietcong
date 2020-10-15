using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Playerinfo", menuName = "ScriptableObjects/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    public int ID;
    public Material PlayerColor;
}
