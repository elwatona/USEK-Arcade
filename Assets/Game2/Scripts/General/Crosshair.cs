using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public float speed, damage;
    public Transform crosshair;

    Collider2D currentEnemy;

    public void Movement(Vector2 input)
    {
        float x = input.x;
        float y = input.y;

        Vector3 direction = new(x, y);
        direction.Normalize();
        crosshair.position += speed * Time.deltaTime * direction;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentEnemy = other;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentEnemy = null;
        }
    }

    void Shoot()
    {
        Health enemyHealth = currentEnemy.GetComponent<Health>();
        enemyHealth.TakeDamage(damage);
        currentEnemy = null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && currentEnemy != null)
        {
            Shoot();
        }
    }
}
