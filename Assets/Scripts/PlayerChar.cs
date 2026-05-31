using UnityEngine;

public class PlayerChar : MonoBehaviour
{
    [SerializeField] private MovementPlayer playerMovement;
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private StaminaPlayer staminaPlayer;
    [SerializeField] private InteractDetector interactDetector;

    public MovementPlayer Movement => playerMovement;
    
    public StaminaPlayer Stamina => staminaPlayer;
    
    public InventoryManager Inventory => inventoryManager;
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}