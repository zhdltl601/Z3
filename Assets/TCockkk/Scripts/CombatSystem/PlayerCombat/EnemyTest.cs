using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour, IDamageable
{
    public void Hit()
    {
        Debug.Log("�� �ù� �¾ҳ�");
        Destroy(this.gameObject);
    }
}
