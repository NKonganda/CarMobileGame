using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 vel = Vector3.zero;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
 
    [SerializeField] private float followspeed;
  
    [SerializeField] private float rotationspeed;
    // Update is called once per frame
    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }
    private void HandleTranslation()
    {
        var Targetpos = target.TransformPoint(offset);
        transform.position = Vector3.SmoothDamp(transform.position, Targetpos, ref vel, followspeed * Time.deltaTime);


    }
    private void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation,  rotationspeed * Time.deltaTime);
    }
}
