using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public float spd;
    public Transform crosshair;

    public void Movement(Vector2 input)
    {
        float x = input.x;
        float y = input.y;

        Vector3 dir = new(x, y);
        dir.Normalize();
        crosshair.position += spd * Time.deltaTime * dir;

        Debug.Log("move");
    }
}
