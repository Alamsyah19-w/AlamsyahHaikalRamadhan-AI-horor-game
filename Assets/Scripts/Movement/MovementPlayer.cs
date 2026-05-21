using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Vector3 movementDirection;
    private float speed = 5f;
    private Vector3 velocity;
    [SerializeField] private CharacterController characterController;
    private void Update()
    {
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
            velocity= Direction.normalized * speed * Time.deltaTime;
            
        }
        else
        {
            velocity = Vector3.zero;
        }
    }

    public void SetMovementDirection(Vector2 inputDirection)
    {
        movementDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
    }
    public void Movement()
    {
        CalculateVelocity();
        characterController.Move(velocity);
        
    }


}
