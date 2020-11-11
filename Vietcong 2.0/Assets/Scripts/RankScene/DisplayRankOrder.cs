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
    public int FadeInMinigame = 5;
    public float DelayToMenu = 15;

    private int ActivePlayers = HowManyPlayers.HowManyActivePlayers;
    private List<Transform> RankSpotList = new List<Transform>();
    private List<Transform> SortedList = new List<Transform>();

    private Material PlayerColor;
    private int ID;

    void Awake()
    {
        Transform[] TempRank = GetComponentsInChildren<Transform>();

        //Gets all the transform elements and stores them in the list RankSpotList that has the script PlayerRank attached to itself.
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
        //Sets the gameobject active.
        gameObject.SetActive(true);
        //Sets the bool FadedToBlack to true.
        FadedToBlack = true;

        //Goes over each gameobject in the ranklist and disables it.
        foreach (var player in RankPositionPlayer.RankList)
        {
            player.gameObject.SetActive(false);
        }
        StartCoroutine(FadeToBlackAndOpaque());
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
                FadeAmount = FadingColor.a + (FadeInMinigame * Time.deltaTime);
                FadingColor = new Color(FadingColor.r, FadingColor.g, FadingColor.g, FadeAmount);
                FadeToBlackPanel.GetComponent<Image>().color = FadingColor;
                yield return null;               
            }
            //Sets the amount of players active in the SortedList according to the amount of players in the Ranklist.
            int i = 0;
            foreach(var player in RankPositionPlayer.RankList)
            {
                ID = player.gameObject.GetComponent<PlayerFinder>().PlayerInfo.ID;
                PlayerColor = player.gameObject.GetComponent<PlayerFinder>().PlayerInfo.PlayerColor;
                SortedList[i].GetComponent<Renderer>().material = PlayerColor;
                SortedList[i].GetComponentInChildren<PlayerRank>().RankName.text = "Player " + ID.ToString();
                SortedList[i].GetComponentInChildren<PlayerRank>().PositionNumber.text.ToString();
                SortedList[i].GetComponentInChildren<PlayerRank>().PositionNumber.gameObject.SetActive(true);
                SortedList[i].gameObject.SetActive(true);
                i++;
            }           
            yield return new WaitForSeconds(FadeInMinigame);
            FadedToBlack = false;
            StartCoroutine(FadeToBlackAndOpaque());
        }
        else
        {
            while (FadeToBlackPanel.GetComponent<Image>().color.a > 0)
            {
                FadeAmount = FadingColor.a - (FadeInMinigame * Time.deltaTime);
                FadingColor = new Color(FadingColor.r, FadingColor.g, FadingColor.g, FadeAmount);
                FadeToBlackPanel.GetComponent<Image>().color = FadingColor;
                yield return null;
            }
            StartCoroutine(SceneSwitch());
        }
    }

    //This coroutine resets the Rank and Player list and loads the Start Scene.
    IEnumerator SceneSwitch()
    {
        yield return new WaitForSeconds(DelayToMenu);
        //Resets the Player and Rank list.
        PlayerTotal.ResetList();
        RankPositionPlayer.ResetList();

        //Loads in the Start scene.
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
