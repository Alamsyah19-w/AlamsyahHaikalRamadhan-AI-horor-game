using UnityEngine;

public class SightPerception: MonoBehaviour
{
    [SerializeField] private Transform eyeTransform;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float viewDistance = 10f;

    [SerializeField] private float viewAngle = 90f;

    [SerializeField] private LayerMask targetLayer;

    public bool CanSeePlayer{ get; private set;}
    public Vector3 LastSeenPosition { get; private set; }

    private void Update()
    {
        CanSeePlayer = CheckSight();
    }

    public bool CheckSight()
    {
        if (targetTransform == null)
        {
            return false;
        }

        //jarak
        float distancePlayer=Vector3.Distance(eyeTransform.position, targetTransform.position);
        if (distancePlayer > viewDistance)
        {
            return false;
        }

        //fov

        Vector3 directionToPlayer = targetTransform.position - eyeTransform.position;
        float angleToPlayer = Vector3.Angle(eyeTransform.forward, directionToPlayer);

        if (angleToPlayer > viewAngle * 0.5f)
        {
            return false;
        }

        //raycast

        bool isSeeTarget= Physics.Raycast(eyeTransform.position, directionToPlayer.normalized, out RaycastHit hit, viewDistance, targetLayer);

        if (isSeeTarget)
        {
            if (hit.transform == targetTransform)
            {
                LastSeenPosition = targetTransform.position;
                return true;
            }
            
        }
        return false;
    }
    private void OnDrawGizmos()
    {
        if (eyeTransform == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        bool isSeePlayer = CheckSight();
        if (isSeePlayer)
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawWireSphere(eyeTransform.position, viewDistance);

        Vector3 left= Quaternion.Euler(0, -viewAngle /2, 0) * eyeTransform.forward;
        Vector3 right= Quaternion.Euler(0, viewAngle /2, 0) * eyeTransform.forward;

        Gizmos.DrawRay(eyeTransform.position, left * viewDistance);
        Gizmos.DrawRay(eyeTransform.position, right * viewDistance);
    }
}
