using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerSetings")]
    public Stat health;


    [SerializeField]
    float walkSpeed;

    [Header("UnitySettings")]
    Rigidbody playerRB;
    Vector3 movement;
    float camRayLength = 100f;
    int floorMask;

    bool isFalling;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRB = GetComponent<Rigidbody>();
        health.SetValues();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //Move Left/Right
        float moveX = Input.GetAxisRaw("Horizontal");

        //Move Forward/Backward
        float moveZ = Input.GetAxisRaw("Vertical");

        PlayerMovement(moveX, moveZ);
        PlayerTurning();
    }

    void PlayerMovement(float x, float z)
    {
        //This is the functionallity for walking
        movement.Set(x, 0f, z);

        //Ensures the movement is applied consistantly every frame
        movement = movement.normalized * walkSpeed * Time.deltaTime;

        //Moving the players position by adding the movement number
        playerRB.MovePosition(transform.position + movement);
    }

    void PlayerTurning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRB.MoveRotation(newRotation);
        }
    }
}
