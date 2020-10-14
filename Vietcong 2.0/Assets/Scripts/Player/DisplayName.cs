using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour
{
    public float WaitBeforeHiding;
    public Text PlayerNameText;
    public PlayerID Player;
    public Canvas CanvasDisplay;

    // Start is called before the first frame update
    void Start()
    {
        PlayerNameText.text = "Player " + Player.ID;
        StartCoroutine(DisplayNameTemp());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 NamePos = Camera.main.WorldToScreenPoint(this.transform.position);
        PlayerNameText.transform.position = NamePos;
    }

    IEnumerator DisplayNameTemp()
    {
        yield return new WaitForSeconds(WaitBeforeHiding);
        CanvasDisplay.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
