using UnityEngine;

public class DropObjectGameEvent : GameEventBase
{
    [SerializeField] private Rigidbody dropObject;

    public override void Trigger()
    {
        dropObject.useGravity =true;
        base.Trigger();
    }
    
}
