using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWeapon : MonoBehaviour, IWeapon
{
    public float attackRange;
    private Transform damageCaster;
    private DamageCaster caster;

    private void Awake()
    {
        damageCaster = transform.Find("DamageCaster");
        caster = damageCaster.GetComponent<DamageCaster>();
    }

    private void Start()
    {
        caster.Init(attackRange);
    }

    public virtual void Attack()
    {
        // �ִϸ��̼� ���� �Ұ���
        caster.CastEnemy();
    }
}
