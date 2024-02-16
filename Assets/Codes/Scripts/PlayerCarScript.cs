using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerCarScript : BaseCarScript
{
    public float Drivability;



    Vector3 targetPosition;
    public bool NewInput = false;
    Vector3 targetDir;
    Vector3 forward;
    int angle;
    bool startMovement = false;

    private void Start()
    {
        InputManagerScript.instance.UpdateTargetPositionEvent += Instance_UpdateTargetPositionEvent;
    }

    private void Instance_UpdateTargetPositionEvent(Vector3 pos)
    {
        targetPosition = pos;
        NewInput = true;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        startMovement = false;
    }

    public void StartPlayerMovement()
    {
        startMovement = true;
    }

    private void FixedUpdate()
    {
        if(startMovement)
        {
            targetDir = targetPosition - transform.position;
            forward = transform.forward;

            angle = (int)Vector3.SignedAngle(targetDir, forward, Vector3.up);
            if (!GameManagerScript.instance.Drifting)
            {
                RB.velocity = Vector3.zero;
                RB.angularVelocity = Vector3.zero;
            }

            RB.AddRelativeForce(Vector3.forward * ACCELERATION * (GameManagerScript.instance.Drifting ? 1 : 10) * Time.fixedDeltaTime, ForceMode.Acceleration);

            if (NewInput && (angle >= Drivability || angle <= -Drivability))
            {
                if (angle > 0)
                {
                    transform.Rotate(new Vector3(0, -1 * RotatioSpeed * Time.deltaTime, 0));
                }
                else if (angle < 0)
                {
                    transform.Rotate(new Vector3(0, 1 * RotatioSpeed * Time.deltaTime, 0));
                }
            }

            if (RB.angularVelocity.magnitude > MaxRotationSpeed)
            {
                RB.angularVelocity = RB.angularVelocity.normalized * MaxRotationSpeed;
            }
            if (RB.velocity.magnitude > MaxSpeed)
            {
                RB.velocity = RB.velocity.normalized * MaxSpeed;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Enemy"))
        {
            AudioManagerScript.instance.PlayOneShot(AudioClipType.Crash);
            PoolManagerScript.instance.GetParticlesFromPool(ParticleType.Crash).transform.position = collision.transform.position;
            GameManagerScript.instance.Money -= GameManagerScript.CrashPay;
            collision.gameObject.SetActive(false);
        }
    }
}
