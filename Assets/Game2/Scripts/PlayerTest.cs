using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public float life, maxLife;
    public float damage;
    //public BossEnemy boss;


    public void TakeDamage(float dmg)
    {
        if (dmg < 0)
        {
            return;
        }
        else
        {
            life -= dmg;
        }
        Health();
    }

    [ContextMenu("Attack")]
    void Health()
    {
        if (life > maxLife)
        {
            life = maxLife;
        }
        else if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void Attack(IDamageable enemy)
    {
        enemy.TakeDamage(damage);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(collision.name);
            if (collision.TryGetComponent<IDamageable>(out IDamageable damageable))
            damageable.TakeDamage(damage);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
