using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
public class playerManagerScript : MonoBehaviour
{
    PhotonView PV;

    void Awake()
    {
        PV=GetComponent<PhotonView>();
    }
    void Start()
    {
        if(PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
         Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 3, Random.Range(-10.0f, 10.0f));
        PhotonNetwork.Instantiate(Path.Combine("photonPrefabs","player"), position, Quaternion.identity);
        // PhotonNetwork.Instantiate(Path.Combine("photonPrefabs","RifleBullet Variant"), position, Quaternion.identity);
       
    }
}
