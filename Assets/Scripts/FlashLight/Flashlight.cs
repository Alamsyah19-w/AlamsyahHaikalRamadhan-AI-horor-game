using System;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private Light flashlight;
    [SerializeField] private PlayerChar playerChar;
    [SerializeField] private float fullBattery=100;
    [SerializeField] private float batteryDrainRate=1f;
    private float batteryLevel;

    private  bool hasFlashlight => playerChar.Inventory.checkItemInInventory("Flashlight_001");

    public bool HasBattery => batteryLevel >0;

    private void Awake()
    {
        flashlight.enabled = false;
        batteryLevel = fullBattery;

        HUDManager.Instance.BattreyLvlUI.UpdateBattreyUI(batteryLevel,fullBattery);

    }
    private void Update()
    {
        UpdateFlashlightRotation();
        UpdateBattery();
    }

    private void UpdateBattery()
    {
        if (flashlight != null && flashlight.enabled== true)
        {
            if (HasBattery == true)
            {
                batteryLevel -= batteryDrainRate * Time.deltaTime;
            }
            else
            {
                batteryLevel = 0;
                flashlight.enabled = false;
            }
            HUDManager.Instance.BattreyLvlUI.UpdateBattreyUI(batteryLevel,fullBattery);
        }
    }

    private void UpdateFlashlightRotation()
    {
        if (flashlight != null)
        {
            flashlight.transform.rotation = Camera.main.transform.rotation;
        }
    }
    public void RechargeBattery()
    {
        batteryLevel = fullBattery;
        HUDManager.Instance.BattreyLvlUI.UpdateBattreyUI(batteryLevel,fullBattery);
    }
    public void UserFlashlight()
    {
        if (hasFlashlight == true && flashlight != null)
        {
            if (HasBattery)
            {
                flashlight.enabled = !flashlight.enabled;
            }
            else
            {
                flashlight.enabled = false;
            }
        }
    }
    public void SetBattreyLevel(float bt)
    {
        batteryLevel=batteryLevel+bt;
        batteryLevel=Mathf.Clamp(batteryLevel,0,bt);
        HUDManager.Instance.BattreyLvlUI.UpdateBattreyUI(batteryLevel,fullBattery);
    }
}
