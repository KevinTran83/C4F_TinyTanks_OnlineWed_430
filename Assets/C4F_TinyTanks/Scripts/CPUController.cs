using UnityEngine;
using UnityEngine.AI;

public class CPUController : MonoBehaviour
{
    public float range = 10.0f;
    private Movement movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dest = transform.position + Random.insideUnitSphere * range;
        if (NavMesh.SamplePosition(dest, out NavMeshHit hit, 1, NavMesh.AllAreas))
            movement.MoveToDestination(dest);
    }
}
