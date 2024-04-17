using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstanciadorDeProyectiles : MonoBehaviour
{
    [SerializeField] Transform origenDelDisparo;
    [SerializeField] Proyectil prefabProyectil;
    [SerializeField] TMP_Text velocidadTexto;
    public float Velocidad { get; set; }

    private void Awake()
    {
        Velocidad = prefabProyectil.Velocidad;
        if (velocidadTexto)
        {
            ActualizarUIVelocidad();
        }
    }

    public void Disparar()
    {
        DispararProyectil(origenDelDisparo.position, Velocidad);
    }

    public void AdiciónVelocidad(float cantidad)
    {
        Velocidad += cantidad;
        ActualizarUIVelocidad();
    }
    
    private void ActualizarUIVelocidad()
    {
        if (!velocidadTexto)
        {
            return;
        }
        velocidadTexto.text = Velocidad.ToString();
    }

    private void DispararProyectil(Vector3 posicionInicial, float velocidad)
    {
        Proyectil proyectil = Instantiate(prefabProyectil, posicionInicial, Quaternion.identity);
        proyectil.Velocidad = velocidad;
    }


}
