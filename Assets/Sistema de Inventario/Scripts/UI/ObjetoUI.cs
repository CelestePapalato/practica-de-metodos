using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ObjetoUI : MonoBehaviour, IPointerClickHandler
{
    string _objeto;
    public string Item { get { return _objeto; } }
    int _cantidad;

    TMP_Text text;
    Button button;

    private void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
        button = GetComponent<Button>();
    }

    public void actualizarDatos(string objeto, int cantidad)
    {
        _objeto = objeto;
        _cantidad = cantidad;
        _actualizarTexto();
    }

    private void _actualizarTexto()
    {
        text.text = _objeto + " " + _cantidad;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        InventarioUI.current.actualizarObjetoElegido(this);
    }

    public void setInteractable(bool value)
    {
        button.interactable = value;
    }
}
