using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flappyController : MonoBehaviour
{

    public float gravity= 20f; //gravity
    Vector3 velocity;  //downward velocity
    public float jumpHeight=2f; //jump Height
    bool isInScreen=true;
    public CharacterController flappy;

    void Start()
    {
        transform.position= new Vector3(-3,1,-3); //spawn position
    }

    void Update()
    {
        if(transform.position.y<-2.5 || transform.position.y>4.5) // if object is outside the screen
        {
            isInScreen=false;
        }
        velocity.y-= gravity*Time.deltaTime;  //increasing downward velocity with time with gravity factor
        flappy.Move(velocity*Time.deltaTime); //accelerting flappy (downwards) using downward velocity

             
        if(Input.GetButtonDown("Jump")&& isInScreen) //jumping with space button
        {
          velocity.y=Mathf.Sqrt(jumpHeight* 2f * gravity);  //using physics formula to determine initial velocity (v^2 - u^2 = 2as)
        }
    }

}
