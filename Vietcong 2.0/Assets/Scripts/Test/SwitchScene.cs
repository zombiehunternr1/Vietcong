using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadMiniGameScene());
    }


    IEnumerator LoadMiniGameScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Minigame", LoadSceneMode.Single);
    }
}
