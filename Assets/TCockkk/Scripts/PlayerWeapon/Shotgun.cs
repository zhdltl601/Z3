using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Shotgun : Gun
{
    private Ammo am;
    private void OnEnable()
    {
        OnM1 += Shoot;
    }

    protected override void Shoot()
    {
        base.Shoot();
        for(int i = 1; i <= 12; ++i)
        {
            Vector3 dir = Quaternion.Euler(0, Random.Range(-15f, 15f), 0) * transform.forward;
            GameObject clone = Instantiate(ammo, transform.position, Quaternion.identity);
            am = clone.GetComponent<Ammo>();
            am.Shoot(dir);
        }
    }
}
