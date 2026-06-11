using UnityEngine;
using UnityEngine.Events;

public class TriggerBox : MonoBehaviour
{
    [SerializeField] private bool autoActive;
    [SerializeField] private string tag;
    [SerializeField] private bool isOneTime;

    public UnityEvent onTrigger;
    private bool isActive;

    private void Awake()
    {
        isActive =autoActive;
    }
    public void SetActive(bool value)
    {
        isActive=value;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag) && isActive==true)
        {
            onTrigger?.Invoke();
        }
    }
}
