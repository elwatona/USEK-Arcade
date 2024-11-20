using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2B : MonoBehaviour
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
    public void OnJoystickP2()
    {
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(movimientoHorizontal * 0f, movimientoVertical * spd);
    }
}
