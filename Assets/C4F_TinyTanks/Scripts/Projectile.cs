using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float speed = 20;
    public float damage = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = transform.forward * speed;
        Invoke("SelfDestruct", 5.0f);
    }

    private void SelfDestruct() { Destroy(gameObject); }

    void OnCollisionEnter(Collision collision)
    {
        HP targetHP = collision.gameObject.GetComponent<HP>();
        if (targetHP == null) targetHP = collision.gameObject.GetComponentInParent<HP>();
        if (targetHP != null) targetHP.ChangeHP(-damage);
    }
}
