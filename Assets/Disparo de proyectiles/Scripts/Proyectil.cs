using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float Velocidad { get; set; } = 1;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * Velocidad * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
