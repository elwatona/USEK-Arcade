using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public Player pj;
    public Player2 pj2;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _poderBala;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        _rigidbody2D.AddForce(transform.right * _poderBala, ForceMode2D.Force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent<Player>(out pj))
            {
                pj.TakeDamagePlayer(2);
            }
            else if (collision.gameObject.TryGetComponent<Player2>(out pj2))
            {
                pj2.TakeDamagePlayer2(2);
            }
        }
        Destroy(gameObject);
    }
}
