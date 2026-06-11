using UnityEngine;
using UnityEngine.Events;
public abstract class GameEventBase : MonoBehaviour
{
   [SerializeField] private string id;
   [SerializeField] private bool isOneTime;
   public UnityEvent OnEventTrigger;
   public UnityEvent onEventFinish;
   public string ID =>id;
    public void Start()
    {
        GameEventManager.Instance.Register(this);
    }
    public virtual void Trigger()
    {
        OnEventTrigger?.Invoke();
    }
    public virtual void Finish()
    {
        onEventFinish?.Invoke();
        if (isOneTime)
        {
            GameEventManager.Instance.UnRegister(this);
            Destroy(gameObject);
        }
    } 
}
