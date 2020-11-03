using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour
{
    public Text PlayerNameText;
    public PlayerInfo Player;

    // Start is called before the first frame update
    void Start()
    {
        PlayerNameText.text = "P" + Player.ID;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 NamePos = Camera.main.WorldToScreenPoint(this.transform.position);
        PlayerNameText.transform.position = NamePos;
    }

    public void DisableNameDisplay()
    {
        PlayerNameText.enabled = false;
    }
}
