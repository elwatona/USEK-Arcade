using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform posicionA, posicionB, ObjetivoDeSeguimiento1, ObjetivoDeSeguimiento2;
    public float speed = 10;
    Transform enemy;
    public Vector2 direction;

    public float radio;
    public bool isRight = true;

    public bool isEnemyInZone = false;

    void Start()
    {
        enemy = transform;
    }

    void Update()
    {
        if (radio >= (ObjetivoDeSeguimiento1.position - enemy.position).magnitude)
        {
            isEnemyInZone = true;
        }
        else
        {
            isEnemyInZone = false;
        }
        if (isEnemyInZone)
        {
            direction = ObjetivoDeSeguimiento1.position - enemy.position;

        }
        else if (isRight)
        {
            direction = posicionB.position - enemy.position;
        }
        else
        {
            direction = posicionA.position - enemy.position;
        }
        if (direction.magnitude <= radio)
        {
            isRight = !isRight;
        }

        if (radio >= (ObjetivoDeSeguimiento2.position - enemy.position).magnitude)
        {
            isEnemyInZone = true;
        }
        else
        {
            isEnemyInZone = false;
        }
        if (isEnemyInZone)
        {
            direction = ObjetivoDeSeguimiento2.position - enemy.position;

        }
        else if (isRight)
        {
            direction = posicionB.position - enemy.position;
        }
        else
        {
            direction = posicionA.position - enemy.position;
        }
        if (direction.magnitude <= radio)
        {
            isRight = !isRight;
        }

        enemy.position += (Vector3)(direction.normalized * speed * Time.deltaTime);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
