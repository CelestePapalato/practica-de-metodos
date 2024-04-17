using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField]
    private float _velocidad = 15;
    public float Velocidad { get => _velocidad; set => _velocidad = value; }

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rb.AddForce(transform.forward * _velocidad * Time.fixedDeltaTime, ForceMode.VelocityChange);
        Destroy(gameObject, 5);
    }
}
