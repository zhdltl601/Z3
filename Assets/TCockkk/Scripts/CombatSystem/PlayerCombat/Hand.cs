using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : HandWeapon
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public override void Attack()
    {
        base.Attack();
    }
}
