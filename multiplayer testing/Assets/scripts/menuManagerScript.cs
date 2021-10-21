using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuManagerScript : MonoBehaviour
{
    public GameObject loadingMenu, titleMenu, createRoomMenu, roomMenu, selectRoomMenu;
    public bool isLoadingmenu=false , isTitlemenu=false, isCreateRoom=false;
    public bool isRoomMenu=false, isSelectRoomMenu=false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(isLoadingmenu)
        {
            loadingMenu.SetActive(true);
        }

        else
        {
           loadingMenu.SetActive(false); 
        }

        if(isTitlemenu)
        {
            titleMenu.SetActive(true);
        }

        else
        {
            titleMenu.SetActive(false);
        }

        if(isCreateRoom)
        {
            createRoomMenu.SetActive(true);
        }

        else
        {
            createRoomMenu.SetActive(false);
        }

        if(isRoomMenu)
        {
            roomMenu.SetActive(true);
        }

        else
        {
            roomMenu.SetActive(false);
        }

         if(isSelectRoomMenu)
        {
            selectRoomMenu.SetActive(true);
        }

        else
        {
            selectRoomMenu.SetActive(false);
        }


    }

    public void openCreateRoomMenu()
    {
        isTitlemenu=false;
        isCreateRoom=true;   
    }

    public void openRoomMenu()
    {
        isCreateRoom=false;
        isSelectRoomMenu=false;
        isRoomMenu=true;
    }

     public void openSelectRoomMenu()
    {
        isTitlemenu=false;
        isSelectRoomMenu=true;
    }
}
