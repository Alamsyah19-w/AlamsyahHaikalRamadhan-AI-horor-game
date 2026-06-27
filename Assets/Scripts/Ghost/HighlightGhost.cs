using UnityEngine;
using UnityEngine.Events;

public class HighlightGhost : MonoBehaviour
{
    [SerializeField] private float maxDistance = 10;
    [SerializeField] private float dotTreshold=0.8f;
    [SerializeField] private bool autoActive;
    public UnityEvent OnSeeGhost;
    private bool isActive;
    private void Awake()
    {
        isActive=autoActive;
    }
    public void SetActive(bool value)
    {
        isActive=value;
    }

    private bool CheckIsPlayerSeeGhost()
    {
        Transform playerCamera = Camera.main.transform;
        Vector3 ghostDirection = (transform.position-playerCamera.position).normalized;

        float dotResult=Vector3.Dot(playerCamera.forward,ghostDirection);

        if (dotResult >dotTreshold)
        {
            float distance =Vector3.Distance(playerCamera.position,transform.position);
            if (distance < maxDistance)
            {
                return true;
            }
        }
        return false;

    }

    private void Update()
    {
        if (isActive)
        {
            bool isPlayerSeeGhost =CheckIsPlayerSeeGhost();
            if (isPlayerSeeGhost==true)
            {
                OnSeeGhost?.Invoke();
                Destroy(this);
            }

        }
        
    }

}
