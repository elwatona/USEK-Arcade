using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform controladorDisparo;
    public float distance;
    public LayerMask capaPlayer;
    public bool playerInRange;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics2D.Raycast(controladorDisparo.position, transform.right, distance, capaPlayer);
        if (playerInRange)
        {

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorDisparo.position, controladorDisparo.position + transform.right * distance);
    }
}
