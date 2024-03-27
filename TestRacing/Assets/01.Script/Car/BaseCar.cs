using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider LeftWheel;
    public WheelCollider RightWheel;
    public bool motor;
    public bool steering;
}

public class BaseCar : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float Maxmoter;
    public float Maxsteering;
    public float BreakForce;
    
    public int Lab;

    [HideInInspector] public GameManager gameManager;

    public Transform WayPoint;
    public Transform TargetPoint;
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public float motor = 10;
    [HideInInspector] public float steering = 0;
    [HideInInspector] public float Break = 0;
    [HideInInspector] public int WayIndex = 0;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public virtual void  LocalPosition(WheelCollider collider)
    {
        if(collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.position = position;
        visualWheel.rotation = rotation;
    }

    public void FixedUpdate()
    {
        Movement();
    }

    public virtual void Movement()
    {
        foreach(AxleInfo info in axleInfos)
        {
            if (info.steering)
            {
                info.LeftWheel.steerAngle = steering;
                info.RightWheel.steerAngle = steering;
            }
            if (info.motor)
            {
                info.LeftWheel.motorTorque = motor;
                info.RightWheel.motorTorque = motor;
            }

            info.LeftWheel.brakeTorque = Break;
            info.RightWheel.brakeTorque = Break;

            LocalPosition(info.LeftWheel);
            LocalPosition(info.RightWheel);
        }
    }

}
