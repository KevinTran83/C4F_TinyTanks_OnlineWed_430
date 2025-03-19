using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Shoot))]
public class CPUController : MonoBehaviour
{
    public float moveRange = 10.0f;
    public float shootRange = 20.0f;
    public float shootTime = 0.5f;
    private Movement movement;
    private Shoot shoot;

    public Turret turret;
    public Transform target; // @todo Make private

    private Coroutine shootRoutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent<Movement>();
        shoot    = GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dest = transform.position + Random.insideUnitSphere * moveRange;
        if ( movement.HasCompletedPath(0.05f)
          && NavMesh.SamplePosition(dest, out NavMeshHit hit, 1, NavMesh.AllAreas)
           ) movement.MoveToDestination(dest);

        turret.Turn(target.position);

        Vector3 targetDir = (target.position - transform.position).normalized;
        if ( Vector3.Distance(transform.position, target.position) < shootRange
          && Vector3.Dot(targetDir, turret.transform.forward) > 0.9f
          && shootRoutine == null
           ) shootRoutine = StartCoroutine("Shoot");
    }

    private IEnumerator Shoot()
    {
        shoot.Fire();
        yield return new WaitForSeconds(shootTime);
        shootRoutine = null;
    }
}
