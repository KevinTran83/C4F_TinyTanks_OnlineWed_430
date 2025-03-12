using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float speed = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = transform.forward * speed;
        Invoke("SelfDestruct", 5.0f);
    }

    private void SelfDestruct() { Destroy(gameObject); }
}
