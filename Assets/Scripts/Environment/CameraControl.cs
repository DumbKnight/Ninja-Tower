using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //Target
    [Header("Target")]

    public Transform Target;

    private Vector3 TargetPosition;
    //Target

    //Parameters
    [Header("Parameters")]

    public float TrackingSpeed;

    [Space]

    public float Offset;
    //Parameters

    void FixedUpdate()
    {
        if (Target.position.y > transform.position.y - Offset)
        {
            TargetPosition = new Vector3(transform.position.x, Target.transform.position.y + Offset, transform.position.z);
            
            transform.position = Vector3.Lerp(transform.position, TargetPosition, TrackingSpeed * Time.deltaTime);
        }
    }
}
