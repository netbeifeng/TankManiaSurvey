using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_MouseKeyboard : CustomInputMethod
{
    public bool use3DCursor;

    private Vector2 movementInput; 
    private Plane mousePlane;
    private Vector3 screenPosition;
    private Vector3 worldPosPointer;

    new private void Awake()
    {
        base.Awake();
    }

    new void Start()
    {
        //init base class members
        base.Start();
        //mouse collision plane at tank muzzle level
        mousePlane = new Plane(Vector3.down, tankTurret.muzzle.position.y);
        //setting sytem cursor or 3D cursor
        if (!use3DCursor)
        {
            Cursor.SetCursor(tankTurret.crossHair, new Vector2(tankTurret.crossHair.width / 2, tankTurret.crossHair.height / 2), CursorMode.Auto);
            tankTurret.cursor3D.GetComponentInChildren<Renderer>().enabled = false;
        }
        else
        {
            tankTurret.cursor3D.GetComponentInChildren<Renderer>().enabled = true;
            Cursor.visible = false;
        }
    }

    void Update()
    {

        //turret steering with mouse
        screenPosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        //intersect mouse pos with horizontal plane at muzzle height
        if (mousePlane.Raycast(ray, out float distance))
        {
            worldPosPointer = ray.GetPoint(distance);
            tankTurret.CursorAim(worldPosPointer);
            tankTurret.TracerAim(worldPosPointer);
            tankTurret.TurretAim(worldPosPointer);
        }


        //shooting
        if (playerInputActions.Player.Attacking.WasPressedThisFrame())
        {
            tankTurret.Shoot();
        }

        
    }

    //Fixed update because Tank used rigidBody for collision
    private void FixedUpdate()
    {
        //get input from Inputsystem
        movementInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
        if (movementInput != Vector2.zero)
        {
            tankMovement.MoveTank(movementInput);
        }
    }
}
