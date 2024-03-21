using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Gun
{
    Ammo am;
    private void OnEnable()
    {
        OnM1 += Shoot;
    }

    private void OnDisable()
    {
        OnM1 -= Shoot;
    }

    protected override void Shoot()
    {
        base.Shoot();
        GameObject clone = Instantiate(ammo, firePos.position, transform.rotation);
        am = clone.GetComponent<Ammo>();
        Vector3 dir = transform.forward;
        am.Shoot(dir);
    }
}
