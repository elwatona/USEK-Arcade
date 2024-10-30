using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;

    void Awake()
    {
        sr = FindAnyObjectByType<SpriteRenderer>();
        rb = FindAnyObjectByType<Rigidbody2D>();
    }

    public void ColorChange(bool button)
    {
        sr.color = Color.cyan;
        Debug.Log("algo");
    }
}
