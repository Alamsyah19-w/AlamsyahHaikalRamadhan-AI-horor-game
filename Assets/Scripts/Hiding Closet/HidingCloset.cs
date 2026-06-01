using UnityEngine;
using System.Collections;
public class HidingCloset : MonoBehaviour, InterfaceInteract
{
    [SerializeField] private string _name;
    [SerializeField] private Transform hidingPosition;
    [SerializeField] private Transform unhidePosition;
    [SerializeField] private float hideDuration = 1f;
    [SerializeField] private Door door;
    private PlayerChar hidingPlayer;

    private Coroutine hideCoroutine;
    private Coroutine unhideCoroutine;

    public string Name => _name;

    public IEnumerator HidePlayer()
    {
        hidingPlayer.Movement.SetEnabled(true);
        hidingPlayer.Camera.SetCameraInput(false);
        hidingPlayer.Movement.SetEnabled(false);
        hidingPlayer.InteractDetector.SetEnabled(false);
        hidingPlayer.Camera.ResetCameraRotation();

        door.OpenDoor();
        yield return new WaitWhile(() => door.IsAnimating);

        float time = 0f;
        Vector3 startPosition = hidingPlayer.transform.position;
        float startRotation=hidingPlayer.Camera.panAxis;

        while (time < hideDuration)
        {
            time += Time.deltaTime;
            hidingPlayer.transform.position = Vector3.Lerp(startPosition, hidingPosition.position, time / hideDuration);
            float panAxis = Mathf.Lerp(startRotation, hidingPosition.eulerAngles.y, time / hideDuration);
            yield return null;
        }
        hidingPlayer.transform.position = hidingPosition.position;
        hidingPlayer.transform.rotation = hidingPosition.rotation;

        door.CloseDoor();
        yield return new WaitWhile(() => door.IsAnimating);

        hidingPlayer.Input.OnInteractInputEvent.AddListener(Stophide);
    }
    public IEnumerator UnhidePlayer()
    {
        door.OpenDoor();

        yield return new WaitWhile(() => door.IsAnimating);

        float time = 0f;

        Vector3 startPosition = hidingPlayer.transform.position;
        float startRotation = hidingPlayer.Camera.panAxis;

        while (time < hideDuration)
        {
            time += Time.deltaTime;

            hidingPlayer.transform.position = Vector3.Lerp(startPosition, unhidePosition.position, time / hideDuration);
            float panAxis = Mathf.Lerp(startRotation, unhidePosition.eulerAngles.y, time / hideDuration);

            hidingPlayer.Camera.SetPanAxisValue(panAxis);
            yield return null;
        }

        hidingPlayer.transform.position = unhidePosition.position;
        hidingPlayer.transform.rotation = unhidePosition.rotation;
        door.CloseDoor();

        hidingPlayer.Camera.SetCameraInput(true);
        hidingPlayer.Movement.SetEnabled(true);
        hidingPlayer.InteractDetector.SetEnabled(true);
        hidingPlayer.SetHiding(false);
        
        hidingPlayer.Input.OnInteractInputEvent.RemoveListener(Stophide);
        
        yield return new WaitWhile(() => door.IsAnimating);
        
        hidingPlayer = null;
    }

    public void Stophide()
    {
        if (unhideCoroutine != null)
        {
            StopCoroutine(unhideCoroutine);
        }
        StartCoroutine(UnhidePlayer());
    }

    public void Interact(PlayerChar player)
    {
        if (hidingPosition != null && unhidePosition != null && door != null)
        {
            hidingPlayer = player;
            if (hideCoroutine != null)
            {
                StopCoroutine(hideCoroutine);
            }
        }
        hideCoroutine = StartCoroutine(HidePlayer());
    }
}
