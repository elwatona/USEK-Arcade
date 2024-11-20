using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform posicionA, posicionB, ObjetivoDeSeguimiento;
    public float speed = 10;
    Transform enemy;
    public Vector2 direction;

    public float radio;
    public bool isRight = true;

    public bool isEnemyInZone = false;


    // Start is called before the first frame update
    void Start()
    {
        enemy = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (radio >= (ObjetivoDeSeguimiento.position - enemy.position).magnitude)
        {
            isEnemyInZone = true;
        }
        else
        {
            isEnemyInZone = false;
        }
        if (isEnemyInZone)
        {
            direction = ObjetivoDeSeguimiento.position - enemy.position;

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
