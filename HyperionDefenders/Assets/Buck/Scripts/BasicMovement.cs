using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float walkSpeed = 8f;
    
    // Update is called once per frame
    void Update() {
        
        //checks WASD \both horizontals and both verticles/
        Vector3 PullPlayer = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        // moves player?
        //Transform.Translate(transform.position + PullPlayer * walkSpeed);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * walkSpeed, Space.World);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * walkSpeed, Space.World);

    }
}
