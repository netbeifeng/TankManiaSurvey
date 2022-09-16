using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Sample : CustomInputMethod
{

    new private void Awake()
    {
        //init base awake
        base.Awake();
    }


    new void Start()
    {
        //init base start
        base.Start();
    }


    void Update()
    {

    }

    //Fixed update because Tank used rigidBody for collision
    private void FixedUpdate()
    {

    }
}
