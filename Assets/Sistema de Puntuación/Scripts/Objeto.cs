using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Objeto : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    int _puntos;

    public void OnPointerClick(PointerEventData eventData)
    {
        Puntaje.current.ActualizarPuntaje(_puntos);
        Destroy(gameObject);
    }
}
