using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    [Header("References")]
    public float attackRange;
    public LayerMask whatIsEnemy; // 필요하다..

    public void CastEnemy()
    {
        RaycastHit[] isHit = Physics.SphereCastAll(
            transform.position, attackRange, transform.forward, Mathf.Infinity, whatIsEnemy);
        if (isHit.Length > 0)
        {
            foreach (RaycastHit hit in isHit)
            {
                hit.transform.TryGetComponent(out IDamageable damageable);
                damageable.Hit();
            }
        }
        else
        {
            return;
        }
    }

    public void Init(float attackRange)
    {
        this.attackRange = attackRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
