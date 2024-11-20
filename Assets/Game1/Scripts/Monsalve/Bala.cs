using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
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
}
