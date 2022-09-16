using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Movement via 360-degree-analog-stick
///  Aiming via tilting the Left Joycon
/// </summary>
public class Input_Joycon2 : CustomInputMethod
{
    /// <summary>
    /// Using L-Joycon at index 0 for this demo
    /// </summary>
    [SerializeField]
    private int joyconIndex = 0;
    private List<Joycon> joycons;

    private Vector2 controllerAimingInput;
    private Vector2 movementInput;

    [SerializeField]
    private GameObject aimingPointer;
    [SerializeField]
    private float maxAimingDistance = 10.0f;
    [SerializeField]
    private float aimingSpeed = 150.0f;
    private Vector2 aimingPointerRelativePosition;

    // Joycon GetButtonDown seems to not be in sync with FixedUpdate()
    private bool _canShoot = true;

    new private void Awake()
    {
        base.Awake();
        aimingPointerRelativePosition = Vector2.zero;
    }

    new private void Start()
    {
        base.Start();
        movementInput = Vector3.zero;
        joycons = JoyconManager.Instance.j;
    }

    private void Update()
    {
        if (joycons.Count >= joyconIndex + 1)
        {
            Joycon j = joycons[joyconIndex];

            // Shoot
            if (_canShoot)
            {
                if (j.GetButtonDown(Joycon.Button.DPAD_DOWN) || j.GetButtonDown(Joycon.Button.SR))
                {
                    _canShoot = false;
                    StartCoroutine(ShootCooldown());
                    tankTurret.Shoot();
                }
            }
        }
        /*else
        {
            joycons = JoyconManager.Instance.j;
        }*/
    }

    private void FixedUpdate()
    {
        if (joycons.Count >= joyconIndex + 1)
        {
            Joycon j = joycons[joyconIndex];

            // Aiming
            HandleAimingPointer(j);

            // Movement
            float[] analogStick = j.GetStick();
            movementInput = new Vector2(-analogStick[1], analogStick[0]);
            if (movementInput.magnitude > 0.1f)
            {
                tankMovement.MoveTank(movementInput);
            }
        }
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        _canShoot = true;
    }

    private void HandleAimingPointer(Joycon j)
    {
        var tankPos = tankMovement.transform.position;
        var pointerY = aimingPointer.transform.position.y;
        var pointerPos2D = new Vector2(tankPos.x, tankPos.z) + aimingPointerRelativePosition;
        var pointerPos3D = new Vector3(pointerPos2D.x, pointerY, pointerPos2D.y);
        tankTurret.CursorAim(pointerPos3D);
        tankTurret.TracerAim(pointerPos3D);
        tankTurret.TurretAim(pointerPos3D);

        var accel = j.GetAccel();
        controllerAimingInput = new Vector2(accel.x, -accel.y);
        controllerAimingInput = controllerAimingInput.magnitude < 0.1f ? Vector2.zero : controllerAimingInput;
        aimingPointerRelativePosition += aimingSpeed * Time.deltaTime * controllerAimingInput;
        if (aimingPointerRelativePosition.magnitude > maxAimingDistance)
        {
            aimingPointerRelativePosition = maxAimingDistance * aimingPointerRelativePosition.normalized;
        }
    }
}
