using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2 : MonoBehaviour
{
    public float velocidadJugador2, poderSaltoJugador2;
    public float maximaVidaJugador2, vidaRestanteJugador2;
    float x, y;
    public Transform player2, posicionBala;
    public GameObject escudo;
    GroundChecker groundchecker;
    Rigidbody2D rigidbody2;
    Vector2 direccionEscudo; 
    bool isFlipped2;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        groundchecker = GetComponentInChildren<GroundChecker>();
        vidaRestanteJugador2 = maximaVidaJugador2;
    }
    public void Movimiento_Jugador2(Vector2 input)
    {
        x = input.x;
        if(x != 0)
        {
            Mover_Jugador2_A();
        }
        Flip_Jugador2_Cambio_De_Direccion(input);
    }
    public void Boton_Para_Saltar_Jugador2(bool jumpBotton)
    {
        if(jumpBotton == true && groundchecker.estaTocando)            
        {
            Fuerza_Salto_Jugador2();
        }
    }
    void Mover_Jugador2_A()
    {
        Vector3 direccion2 = new Vector2(x, 0);
        player2.position += direccion2 * velocidadJugador2 * Time.deltaTime;
    }
    public void Escudo(bool value)
    {
        //Debug.Log(value);
        escudo.SetActive(value);
    }
    void Fuerza_Salto_Jugador2()
    {
        rigidbody2.AddForce(Vector2.up * poderSaltoJugador2, ForceMode2D.Impulse);
    }
    void Flip_Jugador2_Cambio_De_Direccion(Vector2 direccion2)
    {
        switch (direccion2)
        {
            case Vector2 left2 when left2.Equals(Vector2.left):
                transform.rotation = Quaternion.Euler(0,180,0);
                isFlipped2 = true;
                break;
            case Vector2 right2 when right2.Equals(Vector2.right):
                transform.rotation = Quaternion.Euler(0,0,0);
                isFlipped2 = false;
                break;
            case Vector2 up2 when up2.Equals(Vector2.up):
                if (isFlipped2)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 45);
                    return;
                }
                transform.rotation = Quaternion.Euler(0, 0, 45);
                break;
            case Vector2 down2 when down2.Equals(Vector2.down):
                if(isFlipped2)
                {
                    transform.rotation = Quaternion.Euler(0, 180, -45);
                    return;
                }
                transform.rotation = Quaternion.Euler(0, 0, -45);
                break;
        }
    }
    public void TakeDamagePlayer2(float damagePlayer2)
    {
        vidaRestanteJugador2 -= damagePlayer2;
        if(vidaRestanteJugador2 <= 0)
        {
            gameObject.SetActive(false);
            GameSceneManager.GameOver();
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            TakeDamagePlayer2(2);
        }
    }
}
