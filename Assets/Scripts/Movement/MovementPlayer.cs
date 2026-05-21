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

    public void SetMovementDirection(Vector2 inputDirection)
    {
        movementDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
    }
    public void Movement()
    {
        if (movementDirection.magnitude > 0.1f)
        {
            velocity= movementDirection * speed * Time.deltaTime;
            
        }
        else
        {
            velocity = Vector3.zero;
        }
        characterController.Move(velocity);
        
    }


}
