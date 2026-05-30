using UnityEngine;
using System.Collections;
public class SlideDoor : Door
{
    [SerializeField] private Vector3 openPosition;
    [SerializeField] private Vector3 closePosition;

    public override void OpenDoor()
    {
        if (AnimatingDoorCoroutine != null)
        {
            StopCoroutine(AnimatingDoorCoroutine);
        }
        AnimatingDoorCoroutine = StartCoroutine(Slide(openPosition));
        base.OpenDoor();
    }
    public override void CloseDoor()
    {
        if (AnimatingDoorCoroutine != null)
        {
            StopCoroutine(AnimatingDoorCoroutine);
        }
        AnimatingDoorCoroutine = StartCoroutine(Slide(closePosition));
        base.CloseDoor();
    }
    private IEnumerator Slide(Vector3 targetPosition)
    {
        isAnimating= true;
        Vector3 startPosition= doorTransform.localPosition;
        float time= 0f;
        while (time < duration)
        {
            time = time + Time.deltaTime;
            Vector3 position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            doorTransform.localPosition= position;
            yield return null;
        }
        doorTransform.localPosition= targetPosition;
        isAnimating= false;
    }
}
