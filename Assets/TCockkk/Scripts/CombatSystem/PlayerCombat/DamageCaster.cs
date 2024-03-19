using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    [Header("References")]
    public float attackRange;
    public LayerMask whatIsEnemy; // 아직 필요없는데 나중에도 필요없을 것 같기도 하고...

    private void Update()
    {

        // 스피어 캐스트 쏴서 범위안에 있으면 걔한테서 IDamageable꺼내오고 있으면 데미지 주기
        // hit에서 무기 정보 확인하고 데미지 입는거 할 듯.
    }

    public void CastEnemy()
    {
        RaycastHit[] isHit = Physics.SphereCastAll(
            transform.position, attackRange, transform.forward);
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
