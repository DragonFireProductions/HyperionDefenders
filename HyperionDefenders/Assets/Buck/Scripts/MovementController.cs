using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    //player changeable
    public float walkSpeed = 9f;

    //players actual speed
    public float playerSpeed;

    
    private Rigidbody rigidBody;

    void Start() {

        playerSpeed = walkSpeed;
        rigidBody = GetComponent<Rigidbody>();

    } 
    void Update() {

        Vector3 dirVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized; //
        GetComponent<Rigidbody>().MovePosition(transform.position + dirVector * Time.deltaTime * playerSpeed);
        

    }

}
