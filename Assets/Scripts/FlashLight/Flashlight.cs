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

    public bool hasBattery => batteryLevel >0;

    private void Awake()
    {
        flashlight.enabled = false;
        batteryLevel = fullBattery;

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
            if (hasBattery == true)
            {
                batteryLevel -= batteryDrainRate * Time.deltaTime;
            }
            else
            {
                batteryLevel = 0;
                flashlight.enabled = false;
            }
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
    }
    public void UserFlashlight()
    {
        if (hasFlashlight == true && flashlight != null)
        {
            if (hasBattery)
            {
                flashlight.enabled = !flashlight.enabled;
            }
            else
            {
                flashlight.enabled = false;
            }
        }
    }
}
