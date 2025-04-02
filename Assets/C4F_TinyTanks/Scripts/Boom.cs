using UnityEngine;

public class Boom : MonoBehaviour
{
    public Transform target;
    public float speed = 1;

    private Vector3 localPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        localPosition = target.InverseTransformPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards ( transform.position,
                                                   target.position + localPosition,
                                                   speed * Time.deltaTime
                                                 );
    }
}
