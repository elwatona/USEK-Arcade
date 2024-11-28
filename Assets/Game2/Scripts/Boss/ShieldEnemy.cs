using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : MonoBehaviour, IDamageable
{
    public BossEnemy bigBoss;
    public float lifeMax, life;
    public float spd;
    public bool isShielding, isProtecting;
    public float shieldTime, shieldTimeTarget;
    public float timeDisapear;
    public Transform protectTarget;
    public Transform[] enemyGoTo;
    public int posIndex;
    public float distanceShield;


    void HealthCheck()
    {
        if (life > lifeMax)
        {
            life = lifeMax;
        }
        else if (life <= 0)
        {
            bigBoss.DeactivateShield();
            isShielding = false;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float dmg)
    {
        if (dmg == 0)
        {
            return;
        }
        else
        {
            life -= dmg;
        }
    }

    void MoveToTarget(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        transform.position += direction.normalized * spd * Time.deltaTime;

        if (direction.magnitude <= 0.1f)
        {
            if (posIndex >= enemyGoTo.Length - 1)
            {
                posIndex = 0;
            }
            else
            {
                posIndex++;
            }
        }
    }

    void ProtectEnemy(float shieldDistance, Transform targetToProtect)
    {
        Vector3 direction = targetToProtect.position - transform.position;
        direction.Normalize();
        
        Vector3 distance = targetToProtect.position - transform.position;
        //distance.Normalize();

        if (distance.magnitude <= shieldDistance)
        {
            bigBoss.ActivateShield();
            isShielding = true;
        }
        else
        {
            bigBoss.DeactivateShield();
            isShielding = false;
        }

        if (distance.magnitude > shieldDistance - 1.5f && isProtecting)
        {
            transform.position += direction * spd * Time.deltaTime;
        }
    }

    void ProtectTimer(Transform targetToProtect)
    {
        Vector3 direction = targetToProtect.position - transform.position;
        direction.Normalize();

        if (isShielding)
        {
            shieldTime -= Time.deltaTime;
        }
        if (shieldTime <= 0)
        {
            isProtecting = false;
            isShielding = false;
            transform.position -= direction * (spd * 2.5f) * Time.deltaTime;

            timeDisapear += Time.deltaTime;
            if (timeDisapear >= 5)
            {
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        posIndex = Random.Range(0, 2);
        shieldTimeTarget = Random.Range(shieldTimeTarget, shieldTimeTarget * 1.5f);
        isProtecting = true;
        shieldTime = shieldTimeTarget;
        life = lifeMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (isProtecting)
        {
            MoveToTarget(enemyGoTo[posIndex]);
        }
        ProtectEnemy(distanceShield, protectTarget);
        ProtectTimer(protectTarget);
        HealthCheck();
    }
}
