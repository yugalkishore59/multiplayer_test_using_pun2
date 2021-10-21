using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class roomListButton : MonoBehaviour
{
    public RoomInfo info;
    public Text buttonText; 
    public GameObject callJoinRoom;
    public GameObject MenuManager;

    public void Setup(RoomInfo ourInfo)
    {
        info= ourInfo;
        buttonText.text = ourInfo.Name;
    }

    public void OnClick()
    {
       photonLauncher joinTheRoom=callJoinRoom.GetComponent<photonLauncher>();
       joinTheRoom.joinRoom(info);
      
    }
}
