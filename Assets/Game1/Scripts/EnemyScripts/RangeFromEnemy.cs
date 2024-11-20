using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFromEnemy : MonoBehaviour
{
    public EnemyCommon enemyCommon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyCommon.isAttacking = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
