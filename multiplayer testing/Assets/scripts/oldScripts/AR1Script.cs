using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class AR1Script : MonoBehaviour
{

    public float damage=10f;      //basic gun specific properties
    public float range=100f;
    public float AR1fireRate=15f;
    private float nextTimeToFire=0f;

    //public Camera fpsCam;
    public GameObject bullet;

    public GameObject bulletHolder;

    bool isFiring=false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((/*Input.GetButtonDown("Fire1")||*/ isFiring)&& Time.time >=nextTimeToFire)  // firing condition
        {   
            nextTimeToFire= Time.time + 1f/AR1fireRate;
            shoot();  
        }


    }

    void shoot()
    {

    //Instantiate(bullet, bulletHolder.transform.position, gameObject.transform.rotation);
    PhotonNetwork.Instantiate(Path.Combine("photonPrefabs","RifleBullet Variant"), bulletHolder.transform.position, gameObject.transform.rotation);
    } 

    public void shootButtonDown()
    {
          isFiring=true;
    }

    public void shootButtonUp()
    {
        isFiring=false;
    }

    }
