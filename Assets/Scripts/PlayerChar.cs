using UnityEngine;

public class PlayerChar : MonoBehaviour
{
    [SerializeField] private MovementPlayer playerMovement;
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private StaminaPlayer staminaPlayer;
    [SerializeField] private InteractDetector interactDetector;
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private InputManager inputManager;

    public MovementPlayer Movement => playerMovement;
    
    public StaminaPlayer Stamina => staminaPlayer;
    
    public InventoryManager Inventory => inventoryManager;

    public CameraManager Camera => cameraManager;
    public InteractDetector InteractDetector => interactDetector;
    public InputManager Input => inputManager;
    public bool isHiding { get; private set; }
    public void SetHiding(bool hiding)
    {
        isHiding = hiding;
    }
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}