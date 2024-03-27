using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour, IDamageable
{
    public void Hit()
    {
        Debug.Log("아 시발 맞았노");
        Destroy(this.gameObject);
    }
}
