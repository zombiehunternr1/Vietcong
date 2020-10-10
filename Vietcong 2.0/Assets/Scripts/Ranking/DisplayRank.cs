using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRank : MonoBehaviour
{
    public Text DisplayRankText;

    public void RankDisplay()
    {
        int Count;
        string PlayerRank = "";

        //Goes over each player in the ranklist and displays them in the DisplayRankText.
        for (Count = 1; Count < RankPosition.RankList.Count; Count++)
        {
            PlayerRank += Count + "." + "Player " + RankPosition.RankList.Count + "\n";
        }
        DisplayRankText.text = PlayerRank;
    }
}
