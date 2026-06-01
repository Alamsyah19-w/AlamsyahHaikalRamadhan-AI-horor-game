using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static PlayerInputAction; 
public class InputManager : MonoBehaviour,IMovementActions
{
    private PlayerInputAction inputActions;
    public UnityEvent<Vector2> OnMoveInputEvent;
    public UnityEvent<bool> onSprintInputEvent;
    public UnityEvent OnInteractInputEvent;
    public UnityEvent OnFlashlightInput;
  
    private void Awake()
    {
        inputActions = new PlayerInputAction();
        inputActions.Enable();

        inputActions.Movement.SetCallbacks(this);
        
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

    public void OnInteractObject(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnInteractInputEvent?.Invoke();
            Debug.Log("Interact");
        }
    }

    public void OnFlashlight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnFlashlightInput?.Invoke();
            
        }
    }
}

