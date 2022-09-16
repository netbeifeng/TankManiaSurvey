using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMobileDrag : CustomInputMethod
{
    public Vector2 aimSensitivity;

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
        Vector2 touch0Pos = playerInputActions.Player.Touch0Pos.ReadValue<Vector2>();
        Vector2 touch1Pos = playerInputActions.Player.Touch1Pos.ReadValue<Vector2>();
        Vector2 touch0Delta = playerInputActions.Player.Touch0Delta.ReadValue<Vector2>();
        Vector2 touch1Delta = playerInputActions.Player.Touch1Delta.ReadValue<Vector2>();
        Vector2 touchDelta;
        Vector2 touchPos;
       
        //check if two fingers are on scree
        float multitouch= playerInputActions.Player.Touch1Press.ReadValue<float>()+ playerInputActions.Player.Touch0Press.ReadValue<float>();
        if (multitouch== 2 )
        {
            //Debug.Log("T0: " + touch0Pos + ", T1: " + touch1Pos);
            //order aim touch to rightmost finger
            if (touch0Pos.x > touch1Pos.x)
            {
                touchPos = touch0Pos;
                touchDelta = touch0Delta;
            }
            else
            {
                touchPos = touch1Pos;
                touchDelta = touch1Delta;
            }
        }
        //just use the one finger aim touch
        else
        {
            touchPos = touch0Pos;
            touchDelta = touch0Delta;
        }
        //border for movement stick
        int leftTouchBorder = (int)(Screen.width * 0.2f);
        if (touchPos.x > leftTouchBorder )
        {
            aimingInput += Vector2.Scale(touchDelta,aimSensitivity);
        }


        Vector3 tankpos = tankMovement.gameObject.transform.position;
        Vector3 aimOffset = new Vector3(aimingInput.x, 0, aimingInput.y);
        worldPosPointer = tankpos + aimOffset;
        tankTurret.CursorAim(worldPosPointer);
        tankTurret.TracerAim(worldPosPointer);
        tankTurret.TurretAim(worldPosPointer);
        if (aimingInput != Vector2.zero)
        {
            lastAim = aimingInput;
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
        //Debug.Log("Movement:" + movementInput.ToString());

        if (movementInput != Vector2.zero)
        {
            tankMovement.MoveTank(movementInput);
        }
    }
}
