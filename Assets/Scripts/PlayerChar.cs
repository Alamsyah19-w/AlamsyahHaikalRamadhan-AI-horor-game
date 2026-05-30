using UnityEngine;

public class PlayerChar : MonoBehaviour
{
    [SerializeField] private MovementPlayer playerMovement;
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private StaminaPlayer staminaPlayer;

    public MovementPlayer Movement => playerMovement;
    
    public StaminaPlayer Stamina => staminaPlayer;
    
    public InventoryManager Inventory => inventoryManager;
}