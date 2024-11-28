using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool estaTocando = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != transform.parent)
        estaTocando = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != transform.parent)
            estaTocando = false;
    }
}
