using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Projectile proj;
    public Transform muzzle;

    public void Fire() { Instantiate(proj, muzzle.position, muzzle.rotation); }
}
