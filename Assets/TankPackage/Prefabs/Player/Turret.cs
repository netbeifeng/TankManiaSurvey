using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Turret : MonoBehaviour
{
    //single bullet prefab working. Further work and proper inheritance design for multiple items still necessary.
    public GameObject bulletPrefab;
    /// <summary>
    /// End of tank barrel to spawn bullets from.
    /// </summary>
    public Transform muzzle;

    //aiming
    public Texture2D crossHair;
    public GameObject cursor3D;



    //shooting
    private Trajectory trajectory;

    private LineRenderer lineRenderer;

    void Start()
    {
        trajectory = new Trajectory();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
        //Set bullet path with curr trajectory
        bullet.GetComponent<TrajectoryMover>().SetTrajectory(trajectory.CalculateTrajectory(muzzle.position, transform.forward, 30f, 2));
    }

    /// <summary>
    /// Function for crosshair target position
    /// </summary>
    /// <param name="targetWSPos">Only x and z is important because y is set to tank muzzle height</param>
    public void CursorAim(Vector3 targetWSPos)
    {
        Vector3 target = new Vector3(targetWSPos.x, muzzle.position.y, targetWSPos.z);
        cursor3D.transform.position = target;
    }

    /// <summary>
    /// Function for tracer target position
    /// </summary>
    /// <param name="targetWSPos">Only x and z is important because y is set to tank muzzle height</param>
    public void TracerAim(Vector3 targetWSPos)
    {
        Vector3 target = new Vector3(targetWSPos.x, muzzle.position.y, targetWSPos.z);
        //line renderer
        lineRenderer.SetPosition(0, muzzle.position);
        lineRenderer.SetPosition(1, target);
    }

    /// <summary>
    /// Function for turret target position
    /// </summary>
    /// <param name="targetWSPos">Only x and z is important because y is set to tank muzzle height</param>
    public void TurretAim(Vector3 targetWSPos)
    {
        Vector3 target = new Vector3(targetWSPos.x, muzzle.position.y, targetWSPos.z);
        transform.LookAt(target);
        transform.eulerAngles = new Vector3(0, transform.rotation.eulerAngles.y, 0);
    }
}
