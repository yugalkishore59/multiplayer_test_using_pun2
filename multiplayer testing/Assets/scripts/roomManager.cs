using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class roomManager : MonoBehaviourPunCallbacks
{
    public static roomManager Instance;

    void Awake()    //to insure that there is only one roommanager in the scene
    {
        if(Instance)  //checks if another roomManager is already in scene
        {
            Destroy(gameObject); // if it is, it Destroy itself
            return;
        }
        DontDestroyOnLoad(gameObject); // if no roommanager is there
        Instance = this; // make itself instance
    }

    public override void OnEnable()
    {
       base.OnEnable();
       SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
       base.OnDisable();
       SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
      if(scene.buildIndex==1)  // game scene
      {
         PhotonNetwork.Instantiate(Path.Combine("photonPrefabs","PlayerManager"), Vector3.zero, Quaternion.identity);
      }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
