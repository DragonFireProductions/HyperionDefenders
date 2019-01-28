using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    
    public Transform target;
    readonly float fieldOfView = 30.0f;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    
    void FixedUpdate() {

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);  // smooths the movement of camera
        transform.position = smoothedPosition;
        Camera.main.fieldOfView = fieldOfView;
        transform.LookAt(target);
    }
}
