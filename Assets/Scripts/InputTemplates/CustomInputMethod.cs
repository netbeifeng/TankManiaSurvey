using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInputMethod : MonoBehaviour
{
    //Input System
    protected PlayerInput playerInput;
    //Input System Class generated from Tank Package
    protected PlayerInputActions playerInputActions;
    protected PlayerMovement tankMovement;
    protected Turret tankTurret;



    virtual protected void Awake()
    {
        //setup Input System components
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    virtual protected void Start()
    {
        //get tank movement function references
        tankMovement = gameObject.GetComponent<PlayerMovement>();
        tankTurret = gameObject.GetComponentInChildren<Turret>();
        
        
    }

}
