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
    private Transform target;

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
        // Movement code
        Vector3 dest = transform.position + Random.insideUnitSphere * moveRange;
        if ( movement.HasCompletedPath(0.05f)
          && NavMesh.SamplePosition(dest, out NavMeshHit hit, 1, NavMesh.AllAreas)
           ) movement.MoveToDestination(dest);

        // Shoot at target code
        if (FoundTarget()) return;

        turret.Turn(target.position);

        Vector3 targetDir = (target.position - transform.position).normalized;
        if ( Vector3.Distance(transform.position, target.position) < shootRange
          && Vector3.Dot(targetDir, turret.transform.forward) > 0.9f
          && shootRoutine == null
           ) shootRoutine = StartCoroutine("Shoot");
    }

    private bool FoundTarget()
    {
        if (target == null)
        {
            Collider[] nearbyEnemies = Physics.OverlapSphere(transform.position, 50.0f);
            for (int i = 0; i < nearbyEnemies.Length; i++)
            {   // If itself, skip to next enemy.
                if (nearbyEnemies[i].gameObject == gameObject) continue;
                target = nearbyEnemies[i].transform;
                break;
            }
        }
        return target == null;
    }

    private IEnumerator Shoot()
    {
        shoot.Fire();
        yield return new WaitForSeconds(shootTime);
        shootRoutine = null;
    }
}
