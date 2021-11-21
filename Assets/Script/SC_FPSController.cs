using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public UnityEngine.AI.NavMeshAgent agent;
    public Transform attackpoint;
    public Animator charAnimator;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor

    }

    private void Attack() {
    	Collider[] hitColliders = Physics.OverlapSphere(attackpoint.position, 4f, LayerMask.GetMask("foeLayer"));
    	Debug.Log(LayerMask.NameToLayer("foeLayer"));
    	foreach (var hitCollider in hitColliders)
        {
        	Debug.Log(hitCollider);
        	if (hitCollider.tag == "foe")
            	hitCollider.SendMessage("getHit", gameObject);
        }
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        Vector2 mouvement = Vector2.zero;
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        if (Input.GetKey(KeyCode.Q))
        	mouvement.x = -1;
        if (Input.GetKey(KeyCode.Z))
        	mouvement.y = 1;
        if (Input.GetKey(KeyCode.D)){
        	mouvement.x = 1;
        	if (Input.GetKey(KeyCode.Q))
        		mouvement.x = 0;
        }
        if (Input.GetKey(KeyCode.S)){
        	mouvement.y = -1;
        	if (Input.GetKey(KeyCode.Z))
        		mouvement.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.F)){
        	charAnimator.SetTrigger("kick");
        	Attack();
        }

        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && GameManager.Instance.State == GameState.Play){
        	GameManager.Instance.UpdateGameState(GameState.Pause);
        }

        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * mouvement.y : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * mouvement.x : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        if (moveDirection == Vector3.zero)
        	charAnimator.SetBool("move", false);
        else
        	charAnimator.SetBool("move", true);

        if (Input.GetKeyDown(KeyCode.L) && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (GameManager.Instance.State == GameState.Play && canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}