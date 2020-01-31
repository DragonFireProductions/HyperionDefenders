using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    NavMeshAgent agent;

    public bool useKeyBoard;
    public bool oneClick;

    [SerializeField]
    float walkSpeed;
    [SerializeField]
    float runSpeed;

    [Header("UnitySettings")]
    public float doubleClickSensativity;
    float doubleClickTimer;
    Rigidbody playerRB;
    Vector3 movement;
    LayerMask movementMask, interactionMask;

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        playerRB = GetComponent<Rigidbody>();
        movementMask = LayerMask.NameToLayer("Ground");
        interactionMask = LayerMask.NameToLayer("Interactable");
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Move Left/Right
        float moveX = Input.GetAxisRaw("Horizontal");

        //Move Forward/Backward
        float moveZ = Input.GetAxisRaw("Vertical");

        if (!useKeyBoard && EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (useKeyBoard)
            KeyBoardMovement(moveX, moveZ);

        else if (Input.GetMouseButtonDown(0))
        {
            ClickMovement();
        }
	}

    void KeyBoardMovement(float x, float z)
    {
        agent.enabled = false;

        //This is the functionallity for walking
        movement.Set(x, 0f, z);

        movement = movement.normalized * walkSpeed * Time.deltaTime;

        playerRB.MovePosition(transform.position + movement);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement = movement.normalized * runSpeed * Time.deltaTime;
        }

        //NEED TO COME BACK AND FINISH SPRINTING IMPLEMENTATION
        //NEEDS TO SUBTRACT ONLY WHEN MOVINGS
        //if (Stamina.CurValue >= 0)
        //{
        //    This is the functionallit for sprinting
        //    if (Input.GetKey(KeyCode.LeftShift))
        //    {
        //        loseStaminaTimer += Time.deltaTime;

        //        if (Stamina.CurValue <= 0)
        //        {
        //            movement = movement.normalized * walkSpeed * Time.deltaTime;
        //        }
        //        else
        //        {
        //            movement = movement.normalized * runSpeed * Time.deltaTime;
        //        }

        //        playerRB.MovePosition(transform.position + movement);

        //        if (loseStaminaTimer >= loseStamina)
        //        {
        //            Stamina.CurValue -= 1;
        //            loseStaminaTimer = 0;
        //        }
        //    }
        //    else
        //    {
        //        recoverStamineTimer += Time.deltaTime;

        //        if (Stamina.CurValue < Stamina.MaxValue)
        //        {
        //            if (recoverStamineTimer >= recoverStamina)
        //            {
        //                Stamina.CurValue += 1;
        //                recoverStamineTimer = 0;
        //            }
        //        }
        //    }
        //}
    }

    void ClickMovement()
    {
        agent.enabled = true;

        agent.speed = walkSpeed;

        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            //Store the object hit by the raycast
            GameObject interactedObject = interactionInfo.collider.gameObject;

            //If the interactedObjects layer is "Interactable"
            //Get the script on that object and call the function
            //MoveToInteraction
            if (interactedObject.layer == interactionMask)
            {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(agent);
            }

            else if (interactedObject.layer == movementMask)
            {
                agent.SetDestination(interactionInfo.point);
            }


        }
    }

    void ClickRun()
    {
        agent.enabled = true;

        agent.speed = runSpeed;

        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            //Store the object hit by the raycast
            GameObject interactedObject = interactionInfo.collider.gameObject;

            //If the interactedObjects layer is "Interactable"
            //Get the script on that object and call the function
            //MoveToInteraction
            if (interactedObject.layer == interactionMask)
            {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(agent);
}

            else if (interactedObject.layer == movementMask)
            {
                agent.SetDestination(interactionInfo.point);
            }


        }
    }
}
