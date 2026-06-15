using UnityEngine;

public class HUDManager : MonoBehaviour
{
    private static HUDManager instance;
    [SerializeField] private StaminaUI staminaUI;
    [SerializeField] private FlashlightBattreyLvlUI battreLvlUI;

    public static HUDManager Instance => instance;
    public StaminaUI StaminaUI => staminaUI;
    public FlashlightBattreyLvlUI BattreyLvlUI=>battreLvlUI;

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
