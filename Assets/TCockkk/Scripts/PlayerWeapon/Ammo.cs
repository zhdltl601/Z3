using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float speed;
    public DamageCaster caster;
    private Rigidbody rb;
  
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, 3f);
    }

    private void Update()
    {
        caster.CastEnemy();
    }

    public void Shoot(Vector3 dir)
    {
        rb.AddForce(dir * speed, ForceMode.Impulse);
    }
}
