using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2 : MonoBehaviour
{
    public float spd2, power2;
    public float lifePlater2, currentLifePlayer2;
    float x, y;
    public Transform player2, spawn;
    public GameObject escudo;
    GroundChecker gc;
    Rigidbody2D rb2;
    Vector2 dEscudo;
    bool isFlipped2;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        gc = GetComponentInChildren<GroundChecker>();
        currentLifePlayer2 = lifePlater2;
    }
    public void Move2(Vector2 input)
    {
        x = input.x;
        if(x != 0)
        {
            MoveT2();
        }
        Flip2(input);
    }
    public void JumpInput2(bool jumpBotton)
    {
        if(jumpBotton == true && gc.estaTocando)            
        {
            Jump2();
        }
    }
    void MoveT2()
    {
        Vector3 direccion2 = new Vector2(x, 0);
        player2.position += direccion2 * spd2 * Time.deltaTime;
    }
    public void Escudo(bool value)
    {
        Debug.Log(value);
        escudo.SetActive(value);
    }
    void Jump2()
    {
        rb2.AddForce(Vector2.up * power2, ForceMode2D.Impulse);
    }
    void Flip2(Vector2 direccion2)
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
        currentLifePlayer2 -= damagePlayer2;
        if(currentLifePlayer2 <= 0)
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
