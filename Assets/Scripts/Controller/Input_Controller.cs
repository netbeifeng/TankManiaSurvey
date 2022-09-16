using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Movement via left analog stick,
///  Aiming via right analog stick
/// </summary>
public class Input_Controller : CustomInputMethod
{
    [SerializeField]
    private float radiusScale;
    private Vector2 movementInput;
    private Vector2 controllerAimingInput;

    [SerializeField]
    private GameObject aimingPointer;

    new private void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        HandleAimingPointer();
        // Shoot
        if (playerInputActions.Player.Attacking.WasPressedThisFrame())
        {
            tankTurret.Shoot();
        }
    }

    private void FixedUpdate()
    {
        //get input from Inputsystem
        movementInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
        if (movementInput != Vector2.zero)
        {
            tankMovement.MoveTank(movementInput);
        }
    }

    private void HandleAimingPointer()
    {
        Vector3 turretPos = tankTurret.transform.position;
        float pointerY = aimingPointer.transform.position.y;
        controllerAimingInput = playerInputActions.Player.ControllerAiming.ReadValue<Vector2>();


        Vector2 pointerPos2D = new Vector2(turretPos.x, turretPos.z) + controllerAimingInput * radiusScale;
        Vector3 pointerPos3D = new Vector3(pointerPos2D.x, pointerY, pointerPos2D.y);


        tankTurret.CursorAim(pointerPos3D);
        tankTurret.TracerAim(pointerPos3D);
        tankTurret.TurretAim(pointerPos3D);
    }
}