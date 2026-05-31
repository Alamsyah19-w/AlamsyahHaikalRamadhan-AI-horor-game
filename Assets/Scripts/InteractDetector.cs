using System;
using UnityEngine;

public class InteractDetector : MonoBehaviour
{
    [SerializeField] private PlayerChar playerChar;
    [SerializeField] private float detectorDistance;
    [SerializeField] private Vector3 detectorBoxSize=Vector3.one;
    [SerializeField] private LayerMask Interactable;
    private InterfaceInteract detectedInteractable;
    private bool isInteracting;
    private void Update()
    {
        UpdateDetection();
    }

    private void UpdateDetection()
    {
        if (isInteracting)
        {
            isInteracting = false;
            return;
        }
        Transform cameraTransform = Camera.main.transform;
        bool isDetectedInteractable =Physics.BoxCast(cameraTransform.position,detectorBoxSize*0.5f,cameraTransform.forward,out RaycastHit hit,Quaternion.identity,detectorDistance,Interactable);

        if (isDetectedInteractable)
        {
            InterfaceInteract interactable = hit.collider.gameObject.GetComponent<InterfaceInteract>();
            //Debug.Log("Hit Object : " + hit.collider.gameObject.name);
            if (interactable != null)
            {
                detectedInteractable = interactable;                
            }
            else
            {
                detectedInteractable = null;
                Debug.LogWarning("Detected object does not implement InterfaceInteract.");
            }

        }

    }
    public void Interact()
    {
        if (detectedInteractable != null)
        {
            detectedInteractable.Interact(playerChar);
            detectedInteractable = null;
            isInteracting = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Transform cameraTransform = Camera.main.transform;
        bool isDetected = Physics.BoxCast(cameraTransform.position,detectorBoxSize*0.5f,cameraTransform.forward, out RaycastHit hit, Quaternion.identity, Interactable);

        if (isDetected)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(cameraTransform.position,cameraTransform.position + cameraTransform.forward * hit.distance);
            Gizmos.DrawWireCube(cameraTransform.position + cameraTransform.forward * hit.distance,detectorBoxSize);
        }
        else
        {
            Gizmos.DrawWireCube(cameraTransform.position,cameraTransform.position + cameraTransform.forward * detectorDistance);
            Gizmos.DrawWireCube(cameraTransform.position + cameraTransform.forward * detectorDistance,detectorBoxSize);
        }
    }
}
