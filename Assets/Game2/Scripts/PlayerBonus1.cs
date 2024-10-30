using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonus1 : MonoBehaviour
{
    public float x;
    public float y;
    public float spd = 10;
    public Transform myTFT;


    public void Move2D(Vector2 input)
    {
        input.Normalize();

        if (input == Vector2.left || input == Vector2.right)
        {
            Vector3 dir = new Vector2(input.x, 0);
            myTFT.position += dir * Time.deltaTime * spd;
        }

        else if (input == Vector2.up || input == Vector2.down)
        {
            Vector3 dir = new Vector2(0, input.y);
            myTFT.position += dir * Time.deltaTime * spd;
        }
    }
}
