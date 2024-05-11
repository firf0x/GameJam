using UnityEngine;


public class NPCFollower : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float raycastDistance = 5f;
    [SerializeField] private LayerMask obstacleLayerMask;
    
    private bool CanSeePlayer()
    {
        RaycastHit hit;
        Vector3 rayDirection = (playerTransform.position - transform.position).normalized;
        if (Physics.Raycast(transform.position, rayDirection, out hit, raycastDistance, ~obstacleLayerMask))
        {
            if (hit.collider.gameObject == playerTransform.gameObject)
            {
                return true;
            }
        }
        return false;
    }
}