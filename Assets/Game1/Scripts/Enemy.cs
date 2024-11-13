using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float spd;
    public float detectionRadius;

    public Transform player,player2;
     //bool precipicio = true
     //float distanciaRaycastPrecipicio;
    Rigidbody2D rb;
    Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    void Update()
    {
        float disToPlayer = Vector2.Distance(transform.position, player.position);
        if(disToPlayer < detectionRadius)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            movement = new Vector2(dir.x, 0);
        }
        else
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement * spd * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
