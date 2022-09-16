using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMovement : MonoBehaviour
{
    /// <summary>
    /// Tank travel speed
    /// </summary>
    public float speed;
    /// <summary>
    /// Tank angular rotation speed
    /// </summary>
    public float rotationSpeed;

    private Rigidbody rb;

    //enemy ai
    Vector2 desiredDirection = Vector2.up;
    public float wallDetectionRange;
    public float playerDetectionRadius;
    //possibilities
    [Range(0f, 1f)]
    public float changeDirRamdomizer;
    public float chaseDetectionRange;

    enum AIStates
    {
        wall,
        roam,
        chase
    }
    AIStates aIStates = AIStates.roam;
    int layerMaskWalls = 1 << 6;
    int layerMaskPlayer = 1 << 7;
    bool statesLocked = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {

    }



    private void FixedUpdate()
    {
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        Collider[] playerColliders = Physics.OverlapSphere(transform.position, playerDetectionRadius, layerMaskPlayer);

        switch (aIStates)
        {
            case AIStates.wall:
                desiredDirection = RotateVector(desiredDirection, 45f * Random.Range(0, 2) * 2 - 1);
                break;
            case AIStates.roam:
                float randomizer = Random.Range(0f, 1f);
                if (randomizer <= changeDirRamdomizer)
                {
                    desiredDirection = RotateVector(desiredDirection, 45f * Random.Range(0, 2) * 2 - 1);
                }

                break;
            case AIStates.chase:

                Vector3 dir = (playerColliders[0].transform.position - transform.position).normalized;
                desiredDirection = new Vector3(dir.x, dir.z);

                break;
            default:
                break;
        }

        //if player is in movement activation distance
        if (playerColliders.Length != 0)
        {

            Vector3 desiredTo3D = new Vector3(desiredDirection.x, 0, desiredDirection.y);


            RaycastHit hit;
            //if moving into a wall
            if (Physics.Raycast(transform.position, desiredTo3D, out hit, wallDetectionRange, layerMaskWalls))
            {
                if (!statesLocked)
                {

                    aIStates = AIStates.wall;
                    statesLocked = true;
                    StartCoroutine(LockState(1f));
                }
            }
            //if not moving into a wall
            else
            {
                aIStates = AIStates.roam;
            }
            //chasing player if close
            if (Vector3.Distance(transform.position, playerColliders[0].transform.position) <= chaseDetectionRange)
            {
                if (!statesLocked)
                {
                    aIStates = AIStates.chase;
                }
            }

            Debug.DrawRay(transform.position, new Vector3(desiredDirection.x, 0, desiredDirection.y) * wallDetectionRange, Color.red);
            MoveTank(desiredDirection);
        }

    }

    IEnumerator LockState(float waitForSeconds)
    {
        yield return new WaitForSeconds(waitForSeconds);
        statesLocked = false;

    }

    //private void FixedUpdate()
    //{
    //    rb.angularVelocity = Vector3.zero;
    //    rb.velocity = Vector3.zero;
    //    Collider[] hitColliders = Physics.OverlapSphere(transform.position, playerDetectionRadius, layerMaskPlayer);
    //    //if player is in movement activation distance
    //    if (hitColliders.Length != 0)
    //    {

    //        Vector3 desiredTo3D = new Vector3(desiredDirection.x, 0, desiredDirection.y);
    //        RaycastHit hit;
    //        //if moving into a wall
    //        if (Physics.Raycast(transform.position, desiredTo3D, out hit, wallDetectionRange, layerMaskWalls))
    //        {
    //            desiredDirection = RotateVector(desiredDirection, 45f * Random.Range(0, 2) * 2 - 1);

    //        }
    //        //if not moving into a wall
    //        else
    //        {
    //            float randomizer = Random.Range(0f, 1f);
    //            if (randomizer <= changeDir)
    //            {
    //                desiredDirection = RotateVector(desiredDirection, 45f * Random.Range(0, 2) * 2 - 1);
    //            }
    //            //chasing player if close
    //            if (Vector3.Distance(transform.position,hitColliders[0].transform.position)<=5f)
    //            {
    //                Vector3 dir = (hitColliders[0].transform.position-transform.position).normalized;
    //                desiredDirection = new Vector3(dir.x, dir.z);
    //            }
    //        }

    //        Debug.DrawRay(transform.position, new Vector3(desiredDirection.x, 0, desiredDirection.y) * wallDetectionRange, Color.red);
    //        MoveTank(desiredDirection);
    //    }

    //}

    /// <summary>
    /// Moves Tank rigidbody according to 360degree input vector
    /// </summary>
    /// <param name="inputVector"></param>
    public void MoveTank(Vector2 inputVector)
    {
        //discretize input vector
        inputVector = ConvertStepInput(inputVector);
        //setup 3D vector
        Vector3 inputVector3D = new Vector3(inputVector.x, 0, inputVector.y);
        //decide wether forward or backward rotation is closer
        if (Vector3.Angle(transform.forward, inputVector3D) > 90)
        {
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(-inputVector3D, Vector3.up), rotationSpeed * Time.fixedDeltaTime));
        }
        else
        {
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(inputVector3D, Vector3.up), rotationSpeed * Time.fixedDeltaTime));
        }
        //start moving with a 5 degree tolerance
        if (Vector3.Angle(transform.forward, inputVector3D) <= 5 || Vector3.Angle(transform.forward, inputVector3D) >= 175)
        {
            rb.MovePosition(transform.position + inputVector3D * Time.fixedDeltaTime * speed);
        }
        //Debug ray showing input direction
        Debug.DrawRay(transform.position, inputVector3D, Color.magenta);
    }

    /// <summary>
    /// Converts 360degree normalized direction vector into discretized 8 value direction pattern
    /// </summary>
    /// <param name="vector">2D input vector</param>
    /// <returns></returns>
    private Vector2 ConvertStepInput(Vector2 vector)
    {

        float angle = Vector2.Angle(vector, Vector2.up);
        Vector2 outVec = Vector2.zero;
        if (Vector2.Angle(vector, Vector2.up) <= 22.5f)
        {
            outVec = Vector2.up;
        }
        else if (Vector2.Angle(vector, Vector2.down) <= 22.5f)
        {
            outVec = Vector2.down;
        }
        else if (Vector2.Angle(vector, Vector2.left) <= 22.5f)
        {
            outVec = Vector2.left;
        }
        else if (Vector2.Angle(vector, Vector2.right) <= 22.5f)
        {
            outVec = Vector2.right;
        }
        else if (Vector2.Angle(vector, new Vector2(0.71f, 0.71f)) < 22.5f)
        {
            outVec = new Vector2(0.71f, 0.71f);
        }
        else if (Vector2.Angle(vector, new Vector2(-0.71f, 0.71f)) < 22.5f)
        {
            outVec = new Vector2(-0.71f, 0.71f);
        }
        else if (Vector2.Angle(vector, new Vector2(0.71f, -0.71f)) < 22.5f)
        {
            outVec = new Vector2(0.71f, -0.71f);
        }
        else if (Vector2.Angle(vector, new Vector2(-0.71f, -0.71f)) < 22.5f)
        {
            outVec = new Vector2(-0.71f, -0.71f);
        }
        return outVec;
    }

    public Vector2 RotateVector(Vector2 v, float degrees)
    {
        //Debug.Log("Change");
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }

}

