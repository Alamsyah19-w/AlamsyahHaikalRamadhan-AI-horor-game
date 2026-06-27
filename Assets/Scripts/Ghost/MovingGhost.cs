using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UIElements;
public class MovingGhost : MonoBehaviour
{
    [SerializeField] private List<Vector3> destinations = new List<Vector3>();
    [SerializeField] private float speed=1;
    [SerializeField] private float distanceTolerance=0.1f;
    [SerializeField] private bool autoNextDestination;

    [SerializeField] private bool playOnAwake=true;

    public UnityEvent OnstartMoving;
    public UnityEvent OnReachDestination;
    public UnityEvent onReachAllDestination;

    private int destinationIndex;
    private Coroutine moveCoroutine;

    private void Start()
    {
        if (playOnAwake)
        {
            MoveToNextDestination();
        }
        
    }
    public void MoveToNextDestination()
    {
        if (destinations.Count>0 && destinations.Count > destinationIndex)
        {
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
                moveCoroutine=null;
            }
            OnstartMoving?.Invoke();
            moveCoroutine= StartCoroutine(moveToTarget(destinations[destinationIndex]));
            destinationIndex =destinationIndex+1;

        }
        else
        {
            onReachAllDestination?.Invoke();
            Destroy(this);
        }
        
    }
    public void RotateToDestination()
    {
        if(destinations.Count >0 && destinations.Count > destinationIndex)
        {
            transform.LookAt(destinations[destinationIndex]);
        }
    }
    private IEnumerator moveToTarget(Vector3 target)
    {
        RotateToDestination();
        while (Vector3.Distance(transform.position,target)>distanceTolerance)
        {
            transform.position =Vector3.MoveTowards(transform.position,target,speed*Time.deltaTime);
            yield return null;
        }
        transform.position=target;
        OnReachDestination?.Invoke();
        if (autoNextDestination)
        {
            MoveToNextDestination();
        }
        else
        {
            if (destinationIndex >=destinations.Count)
            {
                onReachAllDestination?.Invoke();
                Destroy(this);
            }
        }
    }

}
