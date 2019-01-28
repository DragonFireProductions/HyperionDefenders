using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //This is the target that the camera will center on
    [SerializeField]
    Transform target;

    //This is the "harshness" of the camera snapping when following the player
    //The hire it is the shaarper the snap, the smaller it is the 
    //Longer it takes to center the player 
    [SerializeField]
    float smoothSpeed;

    [SerializeField]
    Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPositon = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPositon;
    }
}
