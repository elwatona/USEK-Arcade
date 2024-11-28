using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LIfe : MonoBehaviour
{
    public float lifeEnemy, currentLifeEnemy;
    // Start is called before the first frame update
    void Start()
    {
        currentLifeEnemy = lifeEnemy;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamge(float damage)
    {
        currentLifeEnemy -= damage;
        if (currentLifeEnemy <= 0)
        {
            gameObject.SetActive(false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamge(5);
        }
    }
}
