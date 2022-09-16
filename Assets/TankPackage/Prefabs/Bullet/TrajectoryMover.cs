using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryMover : MonoBehaviour
{
    public float speed;
    public float distanceThreshold;

    Vector3[] trajectoryPoints;
    int targetIdx = 1;
    Vector3 dir;
    private int numReflections;
    void Start()
    {
        numReflections = 0;
       
    }

    void Update()
    {
        //move and rotate bullet according to dir
        transform.Translate(dir * speed * Time.deltaTime,Space.World);
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
        //dist between last visited point and bullet
        float distFromStartPos = (trajectoryPoints[targetIdx - 1] - transform.position).magnitude;
        //dist between last and current point
        float distBetweenIdx = (trajectoryPoints[targetIdx] - trajectoryPoints[targetIdx - 1]).magnitude;
        //next frame after bullet passed the current point
        if (distFromStartPos > distBetweenIdx)
        {
            //if last point reached
            if (targetIdx >= trajectoryPoints.Length-1)
            {
                Terminate();
            }
            //target next point
            else
            {
                numReflections++;
                targetIdx++;
                dir = (trajectoryPoints[targetIdx] - trajectoryPoints[targetIdx-1]).normalized;

            }
        }
    }

    private void Terminate()
    {
        Destroy(gameObject);
    }

    public void SetTrajectory(Vector3[] trajectoryPoints)
    {
        this.trajectoryPoints = trajectoryPoints;
        gameObject.transform.position = trajectoryPoints[0];
        dir = (trajectoryPoints[1] - trajectoryPoints[0]).normalized;
        //print("dir "+dir);
        //print("points: " + trajectoryPoints[0] + " " + trajectoryPoints[1] +" " + trajectoryPoints[2]);
    }

    public int GetNumReflections()
    {
        return numReflections;
    }
}
