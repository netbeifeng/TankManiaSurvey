using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Mobile4 : CustomInputMethod
{
    public float aimDistanceScale;

    private Vector2 movementInput;
    private Vector2 aimingInput;
    private Vector3 worldPosPointer;
    private Vector3 lastAim; 
    
    new private void Awake()
    {
        base.Awake();
    }

    new void Start()
    {
        //init base class members
        base.Start();
        
        lastAim = new Vector2(0, 1f);     
        
    }

    void Update()
    {

        //turret steering mobile ui sticks       
        aimingInput = playerInputActions.Player.Aiming.ReadValue<Vector2>();

        //keeping last stick aim position upon releasing stick
        if (aimingInput == Vector2.zero)
        {
            aimingInput = lastAim;
        }

        Vector3 tankpos = tankMovement.gameObject.transform.position;
        Vector3 aimOffset = new Vector3(aimingInput.x , 0, aimingInput.y )* aimDistanceScale;
        worldPosPointer = tankpos + aimOffset;
        tankTurret.CursorAim(worldPosPointer);
        tankTurret.TracerAim(worldPosPointer);
        tankTurret.TurretAim(worldPosPointer);
        if (aimingInput != Vector2.zero)
        {
            lastAim = aimingInput;
        }
       
        //shooting
        //if (playerInputActions.Player.Attacking.WasPressedThisFrame())
        //{
        //    tankTurret.Shoot();
        //}
    }

    //Fixed update because Tank used rigidBody for collision
    private void FixedUpdate()
    {
        //get input from Inputsystem
        movementInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
        //Debug.Log("Movement:" + movementInput.ToString());

        if (movementInput != Vector2.zero)
        {
            tankMovement.MoveTank(movementInput);
        }
    }
}
