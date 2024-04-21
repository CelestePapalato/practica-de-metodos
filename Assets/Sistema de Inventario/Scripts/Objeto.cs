using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Objeto : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] string objeto;
    [SerializeField] int cantidad;
    public void OnPointerClick(PointerEventData eventData)
    {
        Inventario.current.AgregarObjeto(objeto, cantidad);
        Destroy(gameObject);
    }
}
