using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class DisplayRankOrder : MonoBehaviour
{
    public RectTransform FadeToBlackPanel;
    public bool FadedToBlack;
    public int FadingSpeed = 5;

    private int ActivePlayers = HowManyPlayers.HowManyActivePlayers;
    private List<Transform> RankSpotList = new List<Transform>();
    private List<Transform> SortedList = new List<Transform>();

    void Awake()
    {
        Transform[] TempRank = GetComponentsInChildren<Transform>();

        //Gets all the transform elements and stores them in the list RankSpotList that has the script PlayerRank attached to itself.
        //After that we disable the object.
        foreach (Transform Rankspot in TempRank)
        {
            if (Rankspot.GetComponent<PlayerRank>())
            {
                RankSpotList.Add(Rankspot);
                Rankspot.gameObject.SetActive(false);
            }           
        }
        //Get all the items in the RankSpotList and order the gameobjects by name, set them in a list and store this list in the variable SortedList.
        SortedList = RankSpotList.OrderBy(go => go.name).ToList();
    }

    public void DisplayRank()
    {
        foreach (var player in PlayerTotal.PlayerList)
        {
            player.gameObject.SetActive(false);
        }

        //Starts the couroutine to fade between black and opaque.
        StartCoroutine(FadeToBlackAndOpaque());

        //Sets the amount of players active according to the amount of active players that is stored in the variable SortedList.
        for (int i = 0; i < ActivePlayers; i++)
        {
            SortedList[i].gameObject.SetActive(true);
        }

        //Teleport players to fixed ranked location
        //Make scene visible
        StartCoroutine(FadeToBlackAndOpaque());

        //Resets the Player and Rank list.
        PlayerTotal.ResetList();
        RankPositionPlayer.ResetList();

        //Loads in the Start scene.
        //SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }

    //This coroutine switches the panel from black top opaque and vice versa.
    IEnumerator FadeToBlackAndOpaque()
    {
        //Gets the color component from the panel and stores it in the FadingColor variable.
        Color FadingColor = FadeToBlackPanel.GetComponent<Image>().color;
        float FadeAmount;

        //Checks if the bool FadedToBlack is true or not. If it is it means the panel is black if not then it's opaque.
        if (FadedToBlack)
        {
            while (FadeToBlackPanel.GetComponent<Image>().color.a < 1)
            {
                FadeAmount = FadingColor.a + (FadingSpeed * Time.deltaTime);
                FadingColor = new Color(FadingColor.r, FadingColor.g, FadingColor.g, FadeAmount);
                FadeToBlackPanel.GetComponent<Image>().color = FadingColor;
                yield return null;
            }
        }
        else
        {
            while (FadeToBlackPanel.GetComponent<Image>().color.a > 0)
            {
                FadeAmount = FadingColor.a - (FadingSpeed * Time.deltaTime);
                FadingColor = new Color(FadingColor.r, FadingColor.g, FadingColor.g, FadeAmount);
                FadeToBlackPanel.GetComponent<Image>().color = FadingColor;
                yield return null;
            }
        }
    }
}
