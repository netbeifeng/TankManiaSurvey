using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Janosch Landvogt.
/// Class for calculating projectile trajectories based on dynamic parameter values. Is referenced as object in TrajectoryMover class.
/// </summary>
public class Trajectory
{

    List<Vector3> trajectoryPoints = new List<Vector3>();
    float maximumDistance;
    int maxReflections;
    int layer_mask = LayerMask.GetMask("Reflect");


    /// <summary>
    /// Returns Vec3 array with trajectory cornerpoints. 
    /// </summary>
    /// <param name="startPos"></param>
    /// <param name="direction"></param>
    /// <param name="maximumDistance">Mac ray distance if nothing is hit.</param>
    /// <param name="maxReflections"></param>
    /// <returns></returns>
    public Vector3[] CalculateTrajectory(Vector3 startPos, Vector3 direction, float maximumDistance, int maxReflections)
    {
        trajectoryPoints.Clear();
        trajectoryPoints.Add(startPos);
        this.maximumDistance = maximumDistance;
        this.maxReflections = maxReflections;

        CastRay(startPos, direction);
        return trajectoryPoints.ToArray();
    }


    void CastRay(Vector3 pos, Vector3 dir)
    {
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        //if ray hits something
        if (Physics.Raycast(ray, out hit, maximumDistance, layer_mask))
        {
            CheckHit(hit, dir);
        }
        //if ray hits nothing
        else
        {
            trajectoryPoints.Add(ray.GetPoint(maximumDistance));
        }
    }

    private void CheckHit(RaycastHit hitInfo, Vector3 direction)
    {
        //Ray has hit "Reflect" layer
        //if ray hits "Reflect" tag, reflect trajectory and procede ray
        if (hitInfo.collider.CompareTag("Reflect"))
        {
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);
            trajectoryPoints.Add(hitInfo.point);
            maxReflections--;
            if (maxReflections >= 0)
            {
                CastRay(pos, dir);
            }
        }
        //if ray hits something else on that layer
        else
        {
            trajectoryPoints.Add(hitInfo.point);
        }
    }
}