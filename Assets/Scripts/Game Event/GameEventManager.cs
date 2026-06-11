using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    private static GameEventManager instance;
    private Dictionary<string,GameEventBase> gameEvents = new Dictionary<string, GameEventBase>();

    public static GameEventManager Instance => instance;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance=this;
    }
    public void Register(GameEventBase gameEvent)
    {
        if (gameEvents.ContainsKey(gameEvent.ID) == false)
        {
            gameEvents.Add(gameEvent.ID,gameEvent);
        }
        
    }
    public void UnRegister(GameEventBase gameEvent)
    {
        if (gameEvents.ContainsKey(gameEvent.ID)==true)
        {
            gameEvents.Remove(gameEvent.ID);
        }
    }
    public void TriggerEvent(string id)
    {
        bool isGameEventFound= gameEvents.TryGetValue(id,out GameEventBase gameEvent);

        if (isGameEventFound)
        {
            gameEvent.Trigger();
        }
    }

    public void FinishEvent(string id)
    {
        bool isGameEventFound= gameEvents.TryGetValue(id,out GameEventBase gameEvent);
        if (isGameEventFound)
        {
            gameEvent.Finish();
        }
        
    }

}
