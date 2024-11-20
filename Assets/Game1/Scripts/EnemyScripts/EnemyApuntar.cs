using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyApuntar : MonoBehaviour
{
    public float radioApuntar = 5f;
    public float radioDisparo = 2f;
    public Transform player,player2;
    public Transform posicionBala;
    public GameObject prefabBall;
    public float poderbala = 7f;
    public int contador;
    Vector2 direccion,direccion2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ApuntarEnemy();
        if (radioDisparo >= direccion.magnitude)
        {
            contador++;
            if (contador >= 180)
            {
                Dispararbala();
                contador = 0;
            }
        }

    }
    void ApuntarEnemy()
    {
        direccion = player.position - transform.position;
        direccion2 = player2.position - transform.position;
        if (radioApuntar >= direccion.magnitude)
        {
            transform.right = -direccion;
        }
        if(radioApuntar >= direccion2.magnitude)
        {
            transform.right = -direccion2;
        }

    }
    void Dispararbala()
    {
        GameObject newbala = Instantiate(prefabBall, posicionBala.position, transform.rotation);
        Rigidbody2D rbbala = newbala.GetComponent<Rigidbody2D>();
        rbbala.AddForce(direccion.normalized * poderbala, ForceMode2D.Impulse);
    }
    private void OnDrawGizmos()

    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radioApuntar);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radioDisparo);

    }
}
