using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARbulletScript : MonoBehaviour
{
    public float timetodestroy=0.5f;
    public float ARbulletSpeed=30f;

    // Use this for initialization
    void Start () {
        //GameObject.rigidbody.constantForce
        
    }
    
    // Update is called once per frame
    void Update () {
        timetodestroy = timetodestroy - Time.deltaTime;
        gameObject.transform.position += transform.forward * Time.deltaTime * ARbulletSpeed;
        if (timetodestroy < 0)
        {
            Destroy(gameObject);
        }
    }
}
