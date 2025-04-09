using UnityEngine;
using UnityEngine.Events;

public class Shoot : MonoBehaviour
{
    public Projectile proj;
    public Transform muzzle;
    public UnityEvent onFire;

    public void Fire() { Instantiate(proj, muzzle.position, muzzle.rotation);
                         onFire.Invoke();
                       }
}
