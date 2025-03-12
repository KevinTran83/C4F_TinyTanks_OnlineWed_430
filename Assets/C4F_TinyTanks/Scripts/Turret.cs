using UnityEngine;

public class Turret : MonoBehaviour
{
    public float turnSpeed = 100;

    public void Turn(Vector3 target)
    {
        target.y = transform.position.y;
        Quaternion lookRot = Quaternion.LookRotation(target - transform.position);
        transform.rotation = Quaternion.RotateTowards ( transform.rotation,
                                                        lookRot,
                                                        turnSpeed * Time.deltaTime
                                                      );
    }
}
