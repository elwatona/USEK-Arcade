using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    public static event Action<Collider2D> OnBatteryCollision;
    public float x;
    public float y;
    public float spd = 2;
    public Transform myTFT;

    public void Move2D(Vector2 input)
    {
        
        float speed = Input.GetKey(KeyCode.X) ? 1.5f : spd;
        float acceleration = Input.GetKey(KeyCode.Z) ? 1.5f : 1f;

        if (input != Vector2.zero)
        {
            
            Vector3 dir = Vector3.zero;

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                dir = new Vector3(input.x, 0, 0);
            }
            else
            {
                dir = new Vector3(0, input.y, 0);
            }


            myTFT.position += dir * Time.deltaTime * speed * acceleration;
            transform.up = dir;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Battery")) OnBatteryCollision?.Invoke(collision);
    }
}
