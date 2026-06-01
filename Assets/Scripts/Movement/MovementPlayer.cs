using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float gravityScale = 1;
    [SerializeField] private float acceleration = 0.5f;
    [SerializeField] private float currentSpeed = 5f;
    private bool sprint;
    private float walkSpeed = 5f;
    private float sprintSpeed = 8f;
    private Vector3 movementDirection;
    private Vector3 velocityXZ;

    private float velocityY;
    private bool isGrounded;
    public bool Sprint => sprint;

    public bool Enabled { get; private set; } = true;
    public void SetEnabled(bool isEnabled)
    {
        Enabled = isEnabled;
    }
    
    private void Update()
    {
        Accelerate();
        CheckGrounded();
        ResetVelocityY();
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
            velocityXZ= Direction.normalized * currentSpeed * Time.deltaTime;
            
        }
        else
        {
            velocityXZ = Vector3.zero;
        }
    }
    private void CalculateVelocityY()
    {
        velocityY += Physics.gravity.y * gravityScale * Time.deltaTime;
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
    private void CheckGrounded()
    {
        LayerMask groundLayer = LayerMask.GetMask("Ground");
        isGrounded = Physics.CheckSphere(transform.position, 0.5f, groundLayer);
    }
    private void ResetVelocityY()
    {
        if (isGrounded && velocityY < 0)
        {
            velocityY = -2f;
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
        if (Enabled==true){
            CalculateVelocity();
            CalculateVelocityY();
            
            Vector3 velocity = new Vector3(velocityXZ.x, velocityY, velocityXZ.z);
            
            characterController.Move(velocity);
        }
        
    }

}
