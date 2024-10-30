using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float spd,power;
    float x, y;
    public Transform player;
    GroundChecker gc;
    Rigidbody2D rb;
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gc = GetComponentInChildren<GroundChecker>();
    }

    // Update is called once per frame
    void Update()
    {
       
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

    void Jump()
    {
        rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);  
    }
    void Flip(Vector2 direccion)
    {
        if (direccion == Vector2.right)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direccion == Vector2.left)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(direccion == Vector2.up)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if(direccion == Vector2.down)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }


    }
    
}
