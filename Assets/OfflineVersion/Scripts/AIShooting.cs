using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AIShooting : MonoBehaviour
{
    //single bullet prefab working. Further work and proper inheritance design for multiple items still necessary.
    public GameObject bulletPrefab;
    /// <summary>
    /// End of tank barrel to spawn bullets from.
    /// </summary>
    public Transform muzzle;
    public float shootDetectionRadius;
    public float shootingRate;





    //shooting
    private Trajectory trajectory;
    private bool shooting = false;
    int layerMaskWall = 1 << 6;
    int layerMaskPlayer = 1 << 7;
    int layerMaskBullet = 1 << 8;
    int layerMaskBulletPlayer;



    void Start()
    {
        trajectory = new Trajectory();
        InvokeRepeating("Shooting", 0f, shootingRate);
        layerMaskBulletPlayer = layerMaskBullet | layerMaskPlayer;

    }

    void Update()
    {
        shooting = false;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, shootDetectionRadius, layerMaskBulletPlayer);
        if (hitColliders.Length != 0)
        {
            TurretAim(hitColliders[0].transform.position);
            RaycastHit hit;
            if (!Physics.Raycast(transform.position, hitColliders[0].transform.position, out hit, Vector3.Distance(transform.position, hitColliders[0].transform.position), layerMaskWall))
            {
                shooting = true;
            }
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
        //Set bullet path with curr trajectory
        bullet.GetComponent<TrajectoryMover>().SetTrajectory(trajectory.CalculateTrajectory(muzzle.position, transform.forward, 30f, 2));
    }

    private void Shooting()
    {
        if (shooting)
        {
            Shoot();
        }
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
