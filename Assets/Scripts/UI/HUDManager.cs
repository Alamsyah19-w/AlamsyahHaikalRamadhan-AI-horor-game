using UnityEngine;

public class HUDManager : MonoBehaviour
{
    private static HUDManager instance;
    [SerializeField] private StaminaUI staminaUI;

    public static HUDManager Instance => instance;
    public StaminaUI StaminaUI => staminaUI;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance=this;
    }
}
