using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    public static Puntaje current;

    [SerializeField]
    TMP_Text text;

    int _puntuacion = 0;

    private void Awake()
    {
        current = this;
        _actualizarInterfaz();    
    }

    public void ActualizarPuntaje(int puntos)
    {
        _puntuacion += puntos;
        _actualizarInterfaz();
    }

    private void _actualizarInterfaz()
    {
        if (text)
        {
            text.text = _puntuacion.ToString();
        }
    }
}
