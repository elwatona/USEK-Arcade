using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{
    //public GameManager gm;
    //public Transform spawnBigBullet;
    //public GameObject bigBullet;
    //public Transform player;
    public Transform spawnEnemies;
    public GameObject enemyToSpawn;
    public float lifeMax, life;
    public bool isProtected;


    void Health()
    {
        if (life > lifeMax)
        {
            life = lifeMax;
        }
        else if (life >= 0)
        {
            BossDie();
        }
    }

    public void TakeDamage(float dmg)
    {
        if (dmg == 0)
        {
            return;
        }

        if (!isProtected)
        {
            life -= dmg;
        }
        Health();


    }

    void BossDie()
    {

    }

    public void ActivateShield()
    {
        isProtected = true;
        
    }

    public void DeactivateShield()
    {
        isProtected = false;
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyToSpawn, spawnEnemies.position, transform.rotation);
    }

    void Attack()
    {
        
    }

    void ChargeAttack(bool isAttacking, float bulletPow, float bulletPowTarget)
    {
        if (isAttacking)
        {
            bulletPow += Time.deltaTime;
        }
        if (bulletPow >= bulletPowTarget)
        {
            Attack();
            bulletPow = 0;
            isAttacking = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        life = lifeMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
