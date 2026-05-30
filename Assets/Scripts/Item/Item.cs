using UnityEngine;
using UnityEngine.Events;
public class Item : MonoBehaviour, InterfaceInteract, InterfacePickable
{
    [SerializeField] private ItemData data;
    public string Name => data.name;
    public UnityEvent OnItemPickUp;
    [ContextMenu("Pick Up")]
    public void PickUp(PlayerChar player)
    {
        ItemData newData= new ItemData { ID = data.ID, name = data.name };
        player.Inventory.AddItem(newData);
        OnItemPickUp?.Invoke();
        Destroy(gameObject);
    }
    public void Interact(PlayerChar player)
    {
       
    }

    
}
