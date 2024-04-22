using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventarioUI : MonoBehaviour
{
    public static InventarioUI current { get; private set; }
    [SerializeField] ObjetoUI _objetoUIPrefab;
    Canvas canvas;
    GridLayoutGroup grid;
    TMP_InputField inputField;
    List<ObjetoUI> objects = new List<ObjetoUI>();
    ObjetoUI _elegido;
    int _cantidadAEliminar = 1;
    private void Awake()
    {
        current = this;
        canvas = GetComponent<Canvas>();
        if (!canvas)
        {
            canvas = GetComponentInParent<Canvas>();
        }
        grid = GetComponent<GridLayoutGroup>();
        if (!grid)
        {
            grid = GetComponentInChildren<GridLayoutGroup>();
        }
        inputField = GetComponentInChildren<TMP_InputField>();
        Debug.Log(grid.name);
        canvas.enabled = false;
    }

    public void open()
    {
        Dictionary<string, int> almacenamiento = Inventario.current.Almacenamiento;
        foreach(string item in almacenamiento.Keys)
        {
            _addSlotUI(item, almacenamiento[item]);
        }
        if(objects.Count > 0){
            actualizarObjetoElegido(objects[0]);
        }
        canvas.enabled = true;
    }

    public void close()
    {
        foreach(ObjetoUI objeto in objects)
        {
            Destroy(objeto.gameObject);
        }
        objects.Clear();
        canvas.enabled = false;
    }

    private void _addSlotUI(string item, int quantity)
    {
        ObjetoUI objetoUI = Instantiate(_objetoUIPrefab, grid.gameObject.transform);
        objetoUI.actualizarDatos(item, quantity);
        objects.Add(objetoUI);
    }

    public void EliminarObjeto()
    {
        if (!_elegido)
        {
            Debug.Log("Objeto no elegido");
            return;
        }
        string ITEM = _elegido.Item;
        Inventario.current.QuitarObjeto(ITEM, _cantidadAEliminar);
        if (Inventario.current.Almacenamiento.ContainsKey(ITEM))
        {
            int cantidad = Inventario.current.Almacenamiento[ITEM];
            _elegido.actualizarDatos(ITEM, cantidad);
        }
        else
        {
            objects.Remove(_elegido);
            Destroy(_elegido.gameObject);
            _elegido = null;
            if(objects.Count > 0)
            {
                actualizarObjetoElegido(objects[0]);
            }
        }
    }

    public void actualizarCantidadAEliminar()
    {
        string text = inputField.text;
        Debug.Log(text);
        int cantidad = 1;
        int.TryParse(text, out cantidad);
        _cantidadAEliminar = Mathf.Max(cantidad, 1);
        Debug.Log("InventarioUI | Cantidad a Eliminar = " + _cantidadAEliminar);
    }

    public void actualizarObjetoElegido(ObjetoUI objeto)
    {
        if (!objeto)
        {
            return;
        }
        if (_elegido)
        {
            _elegido.setInteractable(true);
        }
        _elegido = objeto;
        _elegido.setInteractable(false);
    }

    public void actualizarVisibilidad()
    {
        if (!canvas)
        {
            return;
        }
        if (canvas.enabled)
        {
            close();
            return;
        }
        open();
    }
}
