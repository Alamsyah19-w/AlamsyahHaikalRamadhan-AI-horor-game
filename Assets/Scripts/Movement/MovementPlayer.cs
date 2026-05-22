using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    [SerializeField] private float acceleration = 0.5f;
    [SerializeField] private float currentSpeed = 5f;
    private bool sprint;
    private float walkSpeed = 5f;
    private float sprintSpeed = 8f;
    private Vector3 movementDirection;
    private Vector3 velocity;
    
    private void Update()
    {
        Accelerate();
        Movement();
        
        
    }
    private void CalculateVelocity()
    {
        Transform cameraTransform = Camera.main.transform;
        Vector3 xDirection = movementDirection.x * cameraTransform.right;
        Vector3 zDirection = movementDirection.z * cameraTransform.forward;
        Vector3 Direction = xDirection + zDirection;
        Direction.y = 0f;
        if (movementDirection.magnitude > 0.1f)
        {
            velocity= Direction.normalized * currentSpeed * Time.deltaTime;
            
        }
        else
        {
            velocity = Vector3.zero;
        }
    }
    private void Accelerate()
    {
        if (movementDirection.magnitude > 0.1f)
        {
            if (sprint)
            {
                currentSpeed= currentSpeed +acceleration*Time.deltaTime;
            }
            else
            {
                currentSpeed= currentSpeed -acceleration*Time.deltaTime;
            }
            currentSpeed = Mathf.Clamp(currentSpeed, walkSpeed,sprintSpeed);
        }
        else
        {
            currentSpeed = 0f;
        }
    }

    public void SetMovementDirection(Vector2 inputDirection)
    {
        movementDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
    }
    public void SetSprint(bool isSprint)
    {
        sprint = isSprint;
        Debug.Log("Sprint set to: " + sprint);
    }
    public void Movement()
    {
        CalculateVelocity();
        characterController.Move(velocity);
        
    }



}
