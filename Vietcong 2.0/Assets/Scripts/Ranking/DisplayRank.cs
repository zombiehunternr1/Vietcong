using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRank : MonoBehaviour
{
    public Text DisplayRankText;

    public void RankDisplay()
    {
        int i = 0;
        int Count;
        string PlayerRank = "";

        //Reverses the rank list so I have the players in the order in which they died.
        RankPosition.RankList.Reverse();

        //Goes over each player in the ranklist and displays them in the DisplayRankText.
        for (Count = 1; Count <= RankPosition.RankList.Count; Count++)
        {
            PlayerRank += Count + "." + " Player " + RankPosition.RankList[i].GetComponent<PlayerFinder>().PlayerInfo.ID + "\n";
            i++;
        }
        DisplayRankText.text = PlayerRank;
    }
}
