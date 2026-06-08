using UnityEngine;
using System.Collections;
public class GhostSpawner : MonoBehaviour
{
    [SerializeField] private GhostAIController aiController;
    [SerializeField] private float minSpawnDelay = 5f;
    [SerializeField] private float maxSpawnDelay = 8f;
    [SerializeField] private float minSpawnDistance = 3f;
    [SerializeField] private float maxSpawnDistance = 5f;
    private Coroutine spawnCoroutine;
    public void RestartSpawn()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
        spawnCoroutine = StartCoroutine(StartSpwan());
        
    }
    public IEnumerator StartSpwan()
    {
        float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        yield return new WaitForSeconds(spawnDelay);

        if (aiController.Player == null && aiController.Player.IsHiding)
        {
            RestartSpawn();
            yield break;
        }
        SpawnGhost();
        
    }

    public void SpawnGhost()
    {
        float spawnDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        Vector3 spawnPosition = aiController.Player.transform.position - aiController.Player.transform.forward*spawnDistance;
        spawnPosition.y = aiController.transform.position.y;

        aiController.NavMeshAgent.enabled = true;
        aiController.NavMeshAgent.Warp(spawnPosition);
        aiController.transform.LookAt(aiController.Player.transform);

        aiController.gameObject.SetActive(true);
        aiController.BehaviorAgent.SetVariableValue("lastSeenPlayer", aiController.Player.transform.position);
        aiController.BehaviorAgent.enabled = true;

    }
}
