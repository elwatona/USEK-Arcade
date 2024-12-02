using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public float velocidad,poderSalto;
    public float maximaVidaJugador1, vidaRestanteJugador1;
    float x, y;

    public Transform player,posicionBala;
    public GameObject bala;
    public GroundChecker groundchecker;
    Rigidbody2D m_rigidbody;

    Vector2 dBala;
    bool isFlipped;


    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        groundchecker = GetComponentInChildren<GroundChecker>();
        vidaRestanteJugador1 = maximaVidaJugador1;
    }

    public void Movimiento_Jugador1(Vector2 input)
    {
        x = input.x;
        if (x != 0)
        {
            Mover_Jugador1_A();
        }
        Flip_Cambio_De_Direccion_Jugador1(input);
    }
    public void Boton_Salto_Jugador1(bool jumpButton)
    {
        if (jumpButton == true && groundchecker.estaTocando)
        {
            Salto_Jugador1();
        }
    }

    void Mover_Jugador1_A()
    {
        Vector3 direccion = new Vector2(x, 0);
        player.position += direccion * velocidad * Time.deltaTime;
        
    }
    public void Disparar(bool input)
    {
        if (!input) return; //En caso que no se presione la tecla, hara return.
        GameObject newBala = Instantiate(bala, posicionBala.position, transform.rotation);
        Destroy(newBala,1f);
    }

    void Salto_Jugador1()
    {
        m_rigidbody.AddForce(Vector2.up * poderSalto, ForceMode2D.Impulse);  
    }
    void Flip_Cambio_De_Direccion_Jugador1(Vector2 direccion)
    {
        switch (direccion)
        {
            case Vector2 left when left.Equals(Vector2.left):
                transform.rotation = Quaternion.Euler(0, 180, 0);
                isFlipped = true;
                break;
            case Vector2 right when right.Equals(Vector2.right):
                transform.rotation = Quaternion.Euler(0, 0, 0);
                isFlipped = false;
                break;
            case Vector2 up when up.Equals(Vector2.up):
                if (isFlipped)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 45);
                    return;
                }
                transform.rotation = Quaternion.Euler(0, 0, 45);
                break;
            case Vector2 down when down.Equals(Vector2.down):
                if(isFlipped)
                {
                    transform.rotation = Quaternion.Euler(0, 180, -45);
                    return;
                }
                transform.rotation = Quaternion.Euler(0, 0, -45);
                break;
        }
    }
    public void TakeDamage(float damagePlayer)
    {
        vidaRestanteJugador1 -= damagePlayer;
        if(vidaRestanteJugador1 <= 0)
        {
            gameObject.SetActive(false);
            GameSceneManager.GameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Boss"))
        {
            TakeDamage(2);
        }
    }

}
