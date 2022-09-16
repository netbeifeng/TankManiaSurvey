using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Input_Mobile3 : CustomInputMethod
{
    public float aimDistanceScale;

    private Vector2 movementInput;
    private Vector2 aimingInput;
    private Vector3 aimingTarget;
    private Vector3 worldPosPointer;
    private Plane plane;

    private VirtualStickShootMobile3 stick;

    GraphicRaycaster raycasterUI;

    new private void Awake()
    {
        base.Awake();
    }

    new void Start()
    {
        //init base class members
        base.Start();

        worldPosPointer = new Vector3(0, 0, 1);
        plane = new Plane(Vector3.up, Vector3.zero);

        raycasterUI = FindObjectOfType<GraphicRaycaster>();
        stick = FindObjectOfType<VirtualStickShootMobile3>();
    }

    void Update()
    {
        bool shouldDrag = false;
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        foreach (var touch in (Touchscreen.current?.touches ?? new UnityEngine.InputSystem.Utilities.ReadOnlyArray<UnityEngine.InputSystem.Controls.TouchControl>()))
        {
            int currentId = touch.touchId.ReadValue();

            if (currentId == stick.touchId || touch.press.ReadValue() < 0.1f) continue;

            //if (touchId != null && touchId != currentId) continue;

            var pointerEventData = new PointerEventData(EventSystem.current);
            //turret steering mobile ui sticks
            //aimingTarget = touch.position.ReadValue();
            var newAimingInput = playerInputActions.Player.MobileDrag.ReadValue<Vector2>();
            pointerEventData.position = newAimingInput;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            raycasterUI.Raycast(pointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            //foreach (RaycastResult result in results) Debug.Log("Hit " + result.gameObject.name);

            if (results.Count == 0)
            {
                //foreach (int n in movementTouchId) Debug.Log($"Touching {n}");
                Debug.Log($"{currentId}!={stick.touchId}: {touch.press.ReadValue()}, {newAimingInput}");
                aimingInput = newAimingInput;
                shouldDrag = true;
                break;
            }
        }
        
        if (shouldDrag)
        {
            Ray ray = Camera.main.ScreenPointToRay(aimingInput);
            bool hit = plane.Raycast(ray, out var enter);

            if (hit)
            {
                aimingTarget = ray.GetPoint(enter);
                worldPosPointer = aimingTarget;
            }
        }

        tankTurret.CursorAim(worldPosPointer);
        tankTurret.TracerAim(worldPosPointer);
        tankTurret.TurretAim(worldPosPointer);

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
            var oldPos = tankMovement.gameObject.transform.position;
            tankMovement.MoveTank(movementInput);
            var deltaPos = tankMovement.gameObject.transform.position - oldPos;
            worldPosPointer += deltaPos;
        }
    }
}
