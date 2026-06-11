using UnityEngine;
using Unity.Behavior;
using UnityEngine.AI;
using UnityEngine.Events;
using System.Collections;
public class GhostAIController : MonoBehaviour
{
    [SerializeField] private SightPerception sightPerception;
    [SerializeField] private BehaviorGraphAgent behaviorAgent;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private PlayerChar player;

    public BehaviorGraphAgent BehaviorAgent => behaviorAgent;
    public NavMeshAgent NavMeshAgent => navMeshAgent;
    public PlayerChar Player => player;
    public SightPerception SightPerception => sightPerception;
    public UnityEvent OnDespawn;

    public void Despawn()
    {
        StartCoroutine(DespawnAfterEndOfFrame());
    }
    private IEnumerator DespawnAfterEndOfFrame()
    {
        if (behaviorAgent != null)
        {
            behaviorAgent.SetVariableValue("CanSeeTarget", false);
            behaviorAgent.enabled = false;
        }

        if (navMeshAgent != null && navMeshAgent.isOnNavMesh)
        {
            navMeshAgent.ResetPath();
            navMeshAgent.enabled = false;
        }
        OnDespawn?.Invoke();
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(false);

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerChar player = collision.gameObject.GetComponent<PlayerChar>();
            player?.Death();
        }
    }

}
