using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
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

    }

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
        //Debug.DrawRay(transform.position, inputVector3D, Color.magenta);
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
}
