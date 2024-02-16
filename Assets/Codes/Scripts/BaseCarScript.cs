using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class BaseCarScript : MonoBehaviour
{
    public const int ACCELERATION = 2000;

    //Stats
    public float MaxSpeed;
    public float RotatioSpeed;
    public float MaxRotationSpeed;
    public float Speed;

    public Rigidbody RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    protected virtual void OnDisable()
    {
        RB.velocity = Vector3.zero;
        RB.angularVelocity = Vector3.zero;
    }


    private void FixedUpdate()
    {
        RB.AddRelativeForce(Vector3.forward * ACCELERATION * Speed * Time.fixedDeltaTime, ForceMode.Acceleration);
        if (RB.velocity.magnitude > MaxSpeed)
        {
            RB.velocity = RB.velocity.normalized * MaxSpeed;
        }
    }
}
