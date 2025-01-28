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
    public int maximoContador;
    public int contador;
    Vector2 direccionParaJugador1,direccionParaJugador2;

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ApuntarEnemy();
        if (radioDisparo >= direccionParaJugador1.magnitude)
        {
            contador++;
            if (contador >= maximoContador)
            {
                Dispararbala();
                contador = 0;
            }
        }

    }
    void ApuntarEnemy()
    {
        direccionParaJugador1 = player.position - transform.position;
        direccionParaJugador2 = player2.position - transform.position;
        if (radioApuntar >= direccionParaJugador1.magnitude)
        {
            transform.right = direccionParaJugador1;
        }
        if(radioApuntar >= direccionParaJugador2.magnitude)
        {
            transform.right = direccionParaJugador2;
        }

    }

    void Dispararbala()
    {
        GameObject newbala = Instantiate(prefabBall, posicionBala.position, transform.rotation);
        Rigidbody2D rbbala = newbala.GetComponent<Rigidbody2D>();
        //rbbala.AddForce(direccion.normalized * poderbala, ForceMode2D.Impulse);
    }
    private void OnDrawGizmos()

    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radioApuntar);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radioDisparo);

    }
}
