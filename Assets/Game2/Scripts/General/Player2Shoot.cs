using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Shoot : MonoBehaviour
{
    public float damage;
    public Color defaultColor, shootColor;

    Collider2D currentEnemy;
    SpriteRenderer crosshairRenderer;

    void Awake()
    {
        crosshairRenderer = gameObject.GetComponent<SpriteRenderer>();
        crosshairRenderer.color = defaultColor;
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

    void ChangeColor(Color color)
    {
        if (crosshairRenderer != null)
        {
            crosshairRenderer.color = color;
        }
    }

    void ResetColor()
    {
        if (crosshairRenderer != null)
        {
            crosshairRenderer.color = defaultColor;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && currentEnemy != null)
        {
            Shoot();
            ChangeColor(shootColor);
            Invoke("ResetColor", 0.1f);
        }
    }
}
