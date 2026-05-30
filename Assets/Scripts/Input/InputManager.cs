using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static PlayerInputAction; 
public class InputManager : MonoBehaviour,IMovementActions
{
    private PlayerInputAction inputActions;
    public UnityEvent<Vector2> OnMoveInputEvent;
    public UnityEvent<bool> onSprintInputEvent;
  
    private void Awake()
    {
        inputActions = new PlayerInputAction();
        inputActions.Enable();

        inputActions.Movement.SetCallbacks(this);
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Debug.Log("Interact action performed");
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
            OnMoveInputEvent?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onSprintInputEvent?.Invoke(true);
            
            
        }
        else if (context.canceled)
        {
            onSprintInputEvent?.Invoke(false);
            
        }
    }
}

