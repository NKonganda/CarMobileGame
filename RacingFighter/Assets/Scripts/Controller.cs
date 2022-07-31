using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    // Start is called before the first frame update
    private const float multiplier = 1000000.0f;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private float horinp;
    private float verinp;
    private float currentBreakForce;
    private bool isBreaking = false;
    private float SA;

    [SerializeField] FixedJoystick _joystick;
    [SerializeField] private Plane plane;
    [SerializeField] private Vector3 com;
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;

    [SerializeField] private float maxSA;

    [SerializeField] private Transform WheelFL;
    [SerializeField] private Transform WheelFR;
    [SerializeField] private Transform WheelBL;
    [SerializeField] private Transform WheelBR;

    [SerializeField] private WheelCollider WheelFLcollider;
    [SerializeField] private WheelCollider WheelFRcollider;
    [SerializeField] private WheelCollider WheelBLcollider;
    [SerializeField] private WheelCollider WheelBRcollider;
    [SerializeField] private Rigidbody rb;
    
   private void Start()
    {
        rb.centerOfMass = com;
    }
    // Update is called once per frame
    
    private void FixedUpdate()
    {
     
        HandleMotor();
        HandleSteering();
        UpdateWheel();
        if (plane.GetDistanceToPoint(transform.position) > 1.0f)
        {
            transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
            var rb = transform.GetComponent<Rigidbody>().velocity;
            rb.y = 0;
            transform.GetComponent<Rigidbody>().velocity = rb;
        }
    }


    private void HandleMotor()
    {
        horinp = _joystick.Horizontal;
        verinp = _joystick.Vertical;
        isBreaking = false;
        WheelFLcollider.motorTorque = verinp * motorForce * multiplier;
        WheelFRcollider.motorTorque = verinp * motorForce * multiplier;
        WheelBLcollider.motorTorque = verinp * motorForce * multiplier;
        WheelBRcollider.motorTorque = verinp * motorForce * multiplier;
        if (verinp == 0.0f)
        {
            isBreaking = true;
        }
        currentBreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();

    }
    private void ApplyBreaking()
    {
        WheelFLcollider.brakeTorque = currentBreakForce * multiplier;
        WheelFRcollider.brakeTorque = currentBreakForce * multiplier;
        WheelBLcollider.brakeTorque = currentBreakForce * multiplier;
        WheelBRcollider.brakeTorque = currentBreakForce * multiplier;
    }
    private void HandleSteering()
    {
        SA = maxSA * horinp;
        WheelFLcollider.steerAngle = SA;
        WheelFRcollider.steerAngle = SA;
    }
    private void UpdateWheel()
    {
        UpdateSingleWheel(WheelFLcollider, WheelFL);
        UpdateSingleWheel(WheelFRcollider, WheelFR);
        UpdateSingleWheel(WheelBLcollider, WheelBL);
        UpdateSingleWheel(WheelBRcollider, WheelBR);

    }
    private void UpdateSingleWheel(WheelCollider Wheelcollider, Transform Wheel)
    {
        Vector3 pos;
        Quaternion rot;
        Wheelcollider.GetWorldPose(out pos, out rot);
        Wheel.rotation = rot;
        Wheel.position = pos;
    }
    
}
