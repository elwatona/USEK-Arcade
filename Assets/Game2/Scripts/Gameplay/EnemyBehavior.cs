using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float enemySpeed, chaseRange, shootCoolDown, bulletForce;
    public Transform player, spawnBullet;
    public Transform[] patrolPos;
    public GameObject bulletPrefab;
    public bool isChasing = false, onShootingRange = false;
    int currentPatrolIndex;
    float timer = 0;

    void Patrol()
    {
        if (patrolPos.Length == 0) return;

        Vector3 direction = patrolPos[currentPatrolIndex].position - transform.position;
        direction.Normalize();
        transform.position += enemySpeed * Time.deltaTime * direction;

        if (Vector3.Distance(transform.position, patrolPos[currentPatrolIndex].position) <= 1f)
        {
            currentPatrolIndex++;
        }

        if (currentPatrolIndex >= patrolPos.Length)
        {
            currentPatrolIndex = 0;
        }
    }

    void CheckForPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        if (distanceToPlayer < chaseRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }
    }

    void ChasePlayer()
    {
        onShootingRange = true;
        Vector3 direction = player.position - transform.position;
        Vector3 targetPosition = direction + Vector3.one * 90;
        targetPosition.Normalize();
        transform.position += enemySpeed * Time.deltaTime * targetPosition;
    }

    void Shoot()
    {
        timer += Time.deltaTime;

        if (timer >= shootCoolDown && onShootingRange)
        {
            GameObject newBullet = Instantiate(bulletPrefab, spawnBullet.position, Quaternion.identity);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-Vector2.up * bulletForce, ForceMode2D.Impulse);

            Destroy(newBullet, 1.5f);

            timer = 0;
        }
    }


    void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
            Shoot();
        }
        else
        {
            Patrol();
        }

        CheckForPlayer();
    }
}
