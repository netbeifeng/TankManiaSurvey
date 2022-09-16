using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Movement via tilting the Left Joycon,
///  Aiming via 360-degree-analog-stick
/// </summary>
public class Input_Joycon1 : CustomInputMethod
{
    /// <summary>
    /// Reference to a 2d-float-vector representing analog stick input
    /// </summary>
    [SerializeField]
    private int joyconIndex = 0;
    private List<Joycon> joycons;

    private Vector2 controllerAimingInput;
    private Vector2 movementInput;

    [SerializeField]
    private GameObject aimingPointer;
    [SerializeField]
    private float radiusScale;

    // Joycon GetButtonDown seems to not be in sync with FixedUpdate()
    private bool _canShoot = true;

    new private void Awake()
    {
        base.Awake();
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
            if(_canShoot)
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
            var accel = j.GetAccel();
            movementInput = new Vector2(accel.x, -accel.y);
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

        float[] analogStick = j.GetStick();
        controllerAimingInput = new Vector2(-analogStick[1], analogStick[0]);
        controllerAimingInput = controllerAimingInput.magnitude < 0.1f ? Vector2.zero : controllerAimingInput;

        var pointerPos2D = new Vector2(tankPos.x, tankPos.z) + controllerAimingInput * radiusScale;
        var pointerPos3D = new Vector3(pointerPos2D.x, pointerY, pointerPos2D.y);
        tankTurret.CursorAim(pointerPos3D);
        tankTurret.TracerAim(pointerPos3D);
        tankTurret.TurretAim(pointerPos3D);
    }
}
