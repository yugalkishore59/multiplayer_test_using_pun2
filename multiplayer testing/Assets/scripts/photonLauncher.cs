using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using TMPro;
using System.Linq;

public class photonLauncher : MonoBehaviourPunCallbacks
{
    public GameObject menuManager, roomListButtonPrefab, playerListTextPrefab;
    public Transform listofRooms, listOfPlayers;
    public Text roomNameText;
    public InputField RoomName;
    public GameObject startGameButton;
    //public Image roomListInterface;
    void Start()
    {   
        Debug.Log("joining server");
        menuManagerScript setMenu=menuManager.GetComponent<menuManagerScript>();
        setMenu.isTitlemenu=true;
        PhotonNetwork.ConnectUsingSettings(); //connects with photon server according to photon settings (set by you)
    }

    public override void OnConnectedToMaster() //called when we have successfully cnnected to master server (photon)
    {
        Debug.Log("joined server");
        PhotonNetwork.JoinLobby();  // join lobby
        PhotonNetwork.AutomaticallySyncScene= true;
    }

    public override void OnJoinedLobby() //called when we have joined the lobby
    {
       Debug.Log("joined lobby");
       PhotonNetwork.NickName = "player"+ Random.Range(0,1000).ToString("0000");
       
    }

    public void CreateRoom()
    {
        if(RoomName.text.Length<1)
        {return;}
        PhotonNetwork.CreateRoom(RoomName.text);
        menuManagerScript setMenu=menuManager.GetComponent<menuManagerScript>();
        setMenu.isLoadingmenu=true;
        setMenu.isCreateRoom=false;
    }

    public override void OnJoinedRoom()
    {
        menuManagerScript setMenu=menuManager.GetComponent<menuManagerScript>();
        setMenu.isRoomMenu=true;
        setMenu.isLoadingmenu=false;
        setMenu.isSelectRoomMenu=false;
        roomNameText.text= PhotonNetwork.CurrentRoom.Name;

        foreach(Transform trans1 in listOfPlayers)
        {
            Destroy(trans1.gameObject);
        }
        

        Player[] players= PhotonNetwork.PlayerList;
        for(int j=0; j< players.Count(); j++)
        {
           Instantiate(playerListTextPrefab, listOfPlayers.transform).GetComponent<playerListText>().playerListSetup(players[j]);
        }

        startGameButton.SetActive(PhotonNetwork.IsMasterClient);

    }


    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
       menuManagerScript setMenu=menuManager.GetComponent<menuManagerScript>();
       setMenu.isLoadingmenu=false;
       setMenu.isTitlemenu=true;
    }

    public void leaveRoom()
    {
        menuManagerScript setMenu=menuManager.GetComponent<menuManagerScript>();
        setMenu.isLoadingmenu=true;
        setMenu.isRoomMenu=false;
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        menuManagerScript setMenu=menuManager.GetComponent<menuManagerScript>();
        setMenu.isLoadingmenu=false;
        setMenu.isTitlemenu=true;

    /*    foreach(Transform trans in listofRooms)
        {
            Destroy(trans.gameObject);
        }

         foreach(Transform trans1 in listOfPlayers)
       {
            Destroy(trans1.gameObject);
       }
       
    */
    }

    public void joinRoom(RoomInfo info)
    {
      PhotonNetwork.JoinRoom(info.Name);
      menuManagerScript setMenu=menuManager.GetComponent<menuManagerScript>();
        setMenu.isLoadingmenu=true;
        setMenu.isSelectRoomMenu=false;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
         foreach(Transform trans in listofRooms)
         {
            Destroy(trans.gameObject);
         } 

        for(int i=0;i<roomList.Count;i++)
        {
           if(roomList[i].RemovedFromList)
              {continue;}
            
         Instantiate(roomListButtonPrefab, listofRooms.transform).GetComponent<roomListButton>().Setup(roomList[i]);
            
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {   
        Instantiate(playerListTextPrefab, listOfPlayers.transform).GetComponent<playerListText>().playerListSetup(newPlayer);
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }

    

    
}
