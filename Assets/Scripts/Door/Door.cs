using UnityEngine;
using UnityEngine.Events;
public class Door : MonoBehaviour, InterfaceInteract
{
    [SerializeField] protected Transform doorTransform;
    [SerializeField] protected float duration = 1f;
    [SerializeField] protected bool isLocked;
    [SerializeField] protected bool isOpen;
    [SerializeField] protected string keyId;
    protected Coroutine AnimatingDoorCoroutine;
    protected bool isAnimating;
    public bool IsAnimating => isAnimating;

    public UnityEvent OnOpenDoor;
    public UnityEvent OnCloseDoor;
    
    [ContextMenu("Interact Door")]
    public void Interact(PlayerChar player)
    {
        if (isLocked)
        {
            bool hasKey = player.Inventory.checkItemInInventory(keyId);
            if (hasKey)
            {
                isLocked = false;
                OpenDoor();
            }
        }
        else
        {
            if (isOpen)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }

    }
    public virtual void OpenDoor()
    {
        isOpen = true;
        OnOpenDoor?.Invoke();
    }
    public virtual void CloseDoor()
    {
        isOpen = false;
        OnCloseDoor?.Invoke();
        
    }
}
