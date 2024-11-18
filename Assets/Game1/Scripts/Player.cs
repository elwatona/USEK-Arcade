using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float spd,power,poderBala;
    float x, y;

    public Transform player,spawn;
    public GameObject bala;
    GroundChecker gc;
    Rigidbody2D rb;

    Vector2 dBala;
    bool isFlipped;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gc = GetComponentInChildren<GroundChecker>();
    }

    public void Move(Vector2 input)
    {
        x = input.x;
        if (x != 0)
        {
            MoveT();
        }
        Flip(input);
    }
    public void JumpInput(bool jumpButton)
    {
        if (jumpButton == true && gc.estaTocando)
        {
            Jump();
        }
    }

    void MoveT()
    {
        Vector3 direccion = new Vector2(x, 0);
        player.position += direccion * spd * Time.deltaTime;
        
    }
    public void Disparar(bool input)
    {
        if (!input) return; //En caso que no se presione la tecla, hara return.
        GameObject newBala = Instantiate(bala, spawn.position, transform.rotation);
        Rigidbody2D rbBala = newBala.GetComponent<Rigidbody2D>();
        rbBala.AddForce(dBala.normalized * poderBala, ForceMode2D.Impulse);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);  
    }
    void Flip(Vector2 direccion)
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
    
}
