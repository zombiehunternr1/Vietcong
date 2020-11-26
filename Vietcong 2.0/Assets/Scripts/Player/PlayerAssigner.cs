using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Linq;

public class PlayerAssigner : MonoBehaviour
{
    int value = HowManyPlayers.HowManyActivePlayers;

    public List<PlayerInfo> _PlayerInfoList;
    public List<BoolReference> _BoolReferenceList;
    public List<Transform> _SpawnPlayerPositionList;
    public List<Text> _PlayerNameTextList;
    public List<Text> _PlayerReadyTextList;

    public GameObject Prefab;
    public PlayerReadyList ReadyList;

    public PlayerInputManager InputManager;

    void Awake()
    {
        PlayerTotal.ResetList();
        SetupPlayerPrefab();
    }

    void SetupPlayerPrefab()
    {
        for(int i = 0; i < value; i++)
        {
            var Player = Instantiate(Prefab);
            Player.transform.position = _SpawnPlayerPositionList[i].position;
            Player.GetComponent<PlayerFinder>().PlayerInfo = _PlayerInfoList[i];
            Player.GetComponentInChildren<DisplayName>().PlayerNameText = _PlayerNameTextList[i];
            Player.GetComponentInChildren<DisplayName>().Player = _PlayerInfoList[i];
            Player.GetComponent<PlayerReady>().ReadyUI = _PlayerReadyTextList[i];
            Player.GetComponent<PlayerReady>().ReadyList = ReadyList;
            Player.GetComponent<PlayerReady>().Ready = _BoolReferenceList[i];
            PlayerTotal.AddPlayer(Player);
            var SortedList = PlayerTotal.PlayerList.OrderBy(go => go.GetComponent<PlayerFinder>().PlayerInfo.ID).ToList();
            if(SortedList.Count == value)
            {
                _BoolReferenceList.Reverse();
                for (int x = 0; _BoolReferenceList.Count != SortedList.Count; i++)
                {
                    _BoolReferenceList.Remove(_BoolReferenceList[x]);
                }
                _BoolReferenceList.Reverse();
            }
            if(_BoolReferenceList.Count == SortedList.Count)
            {
                ReadyList.AddBool();
            }
        }           
    }
}
