using UnityEngine;

public class ShowGhostGameEvent : GameEventBase
{
    [SerializeField] private GameObject ghostObject;
    [SerializeField] private bool isDestroyAfterFinish;
    public override void Trigger()
    {
        if (ghostObject != null)
        {
            ghostObject.SetActive(true);
        }
        base.Trigger();
    }

    public override void Finish()
    {
        if (ghostObject != null && isDestroyAfterFinish == true)
        {
            Destroy(ghostObject);
        }
        base.Finish();
    }
}
