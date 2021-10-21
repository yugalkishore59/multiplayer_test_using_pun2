﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class playerListText : MonoBehaviourPunCallbacks
{
    Player player;
    public Text playerName;
    
    public void playerListSetup(Player _player)
    {
        player = _player;
        playerName.text=_player.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(player==otherPlayer)
        {
            Destroy(gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }

}
