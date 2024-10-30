using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : MonoBehaviour
{
    public BossEnemy bigBoss;
    public float lifeMax;
    public float life;
    public bool isShielding;
    public float shieldTime;
    public float shieldTimeTarget;


    void ProtectEnemy(float shieldDistance, Transform targetToProtect)
    {
        Vector3 distance = targetToProtect.position - transform.position;
        distance.Normalize();

        if (distance.magnitude <= shieldDistance)
        {
            bigBoss.ActivateShield();
        }
        else
        {
            bigBoss.DeactivateShield();
        }
    }

    void ProtectTimer()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
