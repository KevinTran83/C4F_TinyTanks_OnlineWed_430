using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour
{
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToDestination(Vector3 dest)
    {
        if (!agent.isActiveAndEnabled) return;
        agent.SetDestination(dest);
    }

    public bool HasCompletedPath(float reachDist)
    {
        if (!agent.isActiveAndEnabled) return false;
        return agent.remainingDistance < reachDist;
    }
}
