using System;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    private static HUDManager instance;
    [SerializeField] private StaminaUI staminaUI;
    [SerializeField] private FlashlightBattreyLvlUI battreLvlUI;
    [SerializeField] private InteractionInfoUI intrectionInfo;
    [SerializeField] private CrosshairUI crosshairUI;

    public static HUDManager Instance => instance;

    public StaminaUI StaminaUI => staminaUI;

    public FlashlightBattreyLvlUI BattreyLvlUI=>battreLvlUI;

    public InteractionInfoUI InteractionInfo=>intrectionInfo;

    public CrosshairUI CrosshairUI =>crosshairUI;
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
