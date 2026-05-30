using UnityEngine;
using UnityEngine.Events;
public class Item : MonoBehaviour, InterfaceInteract, InterfacePickable
{
    public UnityEvent OnItenmPickUp;
    [ContextMenu("Pick Up")]
    public void PickUp()
    {
        OnItenmPickUp.Invoke();
        Destroy(gameObject);
    }
    public void Interact()
    {
        PickUp();
    }

    
}
