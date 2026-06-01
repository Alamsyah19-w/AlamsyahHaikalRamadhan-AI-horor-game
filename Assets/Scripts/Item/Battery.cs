using UnityEngine;

public class Battery : Item
{
    public override void PickUp(PlayerChar player)
    {
        base.PickUp(player);
        player.Flashlight.RechargeBattery();
    }
}
