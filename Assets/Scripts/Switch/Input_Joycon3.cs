using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Movement via Left Joycon Analog Stick,
///  Aiming via Tilting the Right Joycon,
///  Shooting with right joycon shoulder button,
///  Reorienting with right joycon D-pad-up
/// </summary>
public class Input_Joycon3 : CustomInputMethod
{
    public bool swapJoyconOrder;
    [Range(0f, 3f)]
    public float xScaler;
    [Range(0f, 3f)]
    public float yScaler;
    // Magic number to counter Janosch's right joycon gyro drift 0.05823f 
    public float counterSpin = 0.05823f;

    
    [SerializeField]
    private GameObject joycon_remote;
    [SerializeField]
    private GameObject joycon_root;

    // Joycon GetButtonDown seems to not be in sync with FixedUpdate()
    private bool _canShoot = true;
    private List<Joycon> joycons;
    private Joycon jL;
    private Joycon jR;

    new private void Awake()
    {
        base.Awake();
    }

    new private void Start()
    {
        base.Start();
        joycons = JoyconManager.Instance.j;
        
        if (joycons.Count >= 2)
        {
            //account for joycon connection order
            if (!swapJoyconOrder)
            {
                jL = joycons[0];
                jR = joycons[1];
            }
            else
            {
                jL = joycons[1];
                jR = joycons[0];
            }
           
        }

    }

    private void Update()
    {
        if (joycons.Count >= 2)
        {
            // Shoot
            if (_canShoot)
            {
                if (jR.GetButtonDown(Joycon.Button.SHOULDER_2))
                {
                    tankTurret.Shoot();
                    _canShoot = false;
                    StartCoroutine(ShootCooldown());
                }
                //resetting remote orientation
                if (jR.GetButtonDown(Joycon.Button.DPAD_UP))
                {
                    Quaternion relativeRot = Quaternion.Inverse(joycon_remote.transform.rotation) * joycon_root.transform.rotation;
                    Vector3 desiredLookAtPoint;
                    Vector3 desiredLookDirection = Vector3.forward;//desiredCameraLookAtPoint - joycon_remote.transform.position;
                    Quaternion desiredRot = Quaternion.LookRotation(desiredLookDirection);
                    joycon_root.transform.rotation = desiredRot * relativeRot;

                }
            }
        }
        else
        {
            Debug.LogError("Only 1 or less joycons connected");
        }
    }


    private void FixedUpdate()
    {
        if (joycons.Count >= 2)
        {
            #region//Aiming
            //Aiming is done in FixedUpdate() because of gyro-drift-counter-motion

            //apply joycon orientation to virtual remote
            joycon_remote.transform.localRotation = jR.GetVector();

            //apply gyro-drift counter rotation to virtual joycon root
            joycon_root.transform.Rotate(Vector3.forward * counterSpin);

            Vector3 joyconForward = new Vector3(joycon_remote.transform.forward.x * xScaler,
                                        joycon_remote.transform.forward.y * yScaler,
                                        1);

            //calculate aimed at screen pos from virtual joycon
            Vector3 screenAimPos = new Vector3(Screen.width / 2 + joyconForward.x * Screen.width / 2,
                                       Screen.height / 2 + joyconForward.y * Screen.height / 2,
                                       1);

            //limit screen pos to screen size
            screenAimPos = new Vector3(Mathf.Clamp(screenAimPos.x, 0, Screen.width),
                                       Mathf.Clamp(screenAimPos.y, 0, Screen.height),
                                       screenAimPos.z);

            //pointer collision plane at tank muzzle level
            Plane pointerPlane = new Plane(Vector3.down, tankTurret.muzzle.position.y);
            //intersect screen pos with horizontal plane at muzzle height
            Ray ray = Camera.main.ScreenPointToRay(screenAimPos);
            if (pointerPlane.Raycast(ray, out float distance))
            {
                Vector3 worldPosPointer = ray.GetPoint(distance);
                tankTurret.CursorAim(worldPosPointer);
                tankTurret.TracerAim(worldPosPointer);
                tankTurret.TurretAim(worldPosPointer);
            }
            #endregion


            #region//Movement
            float[] analogStick = jL.GetStick();
            Vector2 movementInput = new Vector2(analogStick[0], analogStick[1]);
            if (movementInput.magnitude > 0.1f)
            {
                tankMovement.MoveTank(movementInput);
            }
            #endregion
        }
        else
        {
            Debug.LogError("Only 1 or less joycons connected");
        }
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        _canShoot = true;
    }

    public void SwapJoycons()
    {
        Joycon tmp = jR;
        jR = jL;
        jL = tmp;
    }

    public void SetNewDriftValue(string value)
    {
        counterSpin = float.Parse(value);
    }
}
