using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRank : MonoBehaviour
{
    public GameObject DisplayHolder;
    public GameObject PositionHolder;
    public Text PositionNumber;
    public Text RankName;

    void Start()
    {
        Vector3 NamePos = Camera.main.WorldToScreenPoint(DisplayHolder.transform.position);
        RankName.transform.position = NamePos;
        Vector3 PosPos = Camera.main.WorldToScreenPoint(PositionHolder.transform.position);
        PositionNumber.transform.position = PosPos;
    }
}
