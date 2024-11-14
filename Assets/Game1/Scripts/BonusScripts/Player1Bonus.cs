using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Bonus : MonoBehaviour
{
    private Rigidbody2D rb;
    public float spd;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnJoystickP2();
    }
    void OnJoystickP2()
    {
        //Hacer que los jugadores puedan mover la palanca de manera Horizontal o vertical
        float movimientoHorizontal = Input.GetAxisRaw("P1_Horizontal");
        float movimientoVertical = Input.GetAxisRaw("P1_Vertical");
        rb.velocity = new Vector2(movimientoHorizontal * spd, movimientoVertical * 0f);
        Debug.Log(movimientoHorizontal);
        Debug.Log(movimientoVertical);
    }
}
