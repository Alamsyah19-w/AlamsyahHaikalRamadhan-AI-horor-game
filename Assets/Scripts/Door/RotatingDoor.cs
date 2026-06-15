using UnityEngine;
using System.Collections;
public class RotatingDoor : Door
{
   
    [SerializeField] private float openAngle;
    [SerializeField] private float closeAngle;
    public override void OpenDoor()
    {
        if (AnimatingDoorCoroutine != null)
        {
            StopCoroutine(AnimatingDoorCoroutine);
        }
        AnimatingDoorCoroutine = StartCoroutine(RotateDoor(openAngle));
        base.OpenDoor();
    }
    public override void CloseDoor()
    {
        if (AnimatingDoorCoroutine != null)
        {
            StopCoroutine(AnimatingDoorCoroutine);
        }
        AnimatingDoorCoroutine = StartCoroutine(RotateDoor(closeAngle));
        base.CloseDoor();
    }

    private IEnumerator RotateDoor(float targetAngle)
    {
        isAnimating= true;
        float startAngle= doorTransform.localEulerAngles.y;
        
        float time= 0f;
        while (time < duration)
        {
            time = time + Time.deltaTime;
            float angle = Mathf.LerpAngle(startAngle, targetAngle, time / duration);

            doorTransform.localEulerAngles= Quaternion.Euler(0f, angle, 0f).eulerAngles;
            yield return null;
        }
        doorTransform.localEulerAngles= Quaternion.Euler(0f, targetAngle, 0f).eulerAngles;
        isAnimating= false;
    }
    
}
