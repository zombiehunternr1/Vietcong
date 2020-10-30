using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public float DelayReset;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the script DisplayRank and stores it in the variable ShowResult.
      //  var ShowResult = GetComponent<DisplayRank>();
        //Displays the result of the players who came on top.
      //  ShowResult.RankDisplay();       
        //Starts the coroutine LoadMiniGameScene.
        StartCoroutine(LoadMiniGameScene());
      //  Time.timeScale = 0;
    }

    //Once this coroutine gets called it waits 3 seconds before switching to the scene "Minigame".
    IEnumerator LoadMiniGameScene()
    {
        yield return new WaitForSeconds(DelayReset);
      //  Time.timeScale = 1;
        //Clears the playerlist before reloading the scene.
        PlayerTotal.ResetList();
        //Clears the ranklist before reloading the scene.
        RankPosition.ResetList();
        
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
