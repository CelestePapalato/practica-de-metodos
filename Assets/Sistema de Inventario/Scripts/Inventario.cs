using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario current;

    Dictionary<string, int> _almacenamiento = new Dictionary<string, int>();
    public Dictionary<string, int> Almacenamiento { get { return _almacenamiento; } }

    private void Awake()
    {
        current = this;
    }

    public void AgregarObjeto(string objeto, int cantidad)
    {
        if (_almacenamiento.ContainsKey(objeto))
        {
            _almacenamiento[objeto] += cantidad;
        }
        else
        {
            _almacenamiento.Add(objeto, cantidad);
        }
        _imprimirInventario();
    }
    public void QuitarObjeto(string objeto, int cantidad)
    {
        if (!_almacenamiento.ContainsKey(objeto))
        {
            return;
        }
        _almacenamiento[objeto] -= cantidad;
        if (_almacenamiento[objeto] <= 0)
        {
            _almacenamiento.Remove(objeto);
        }
        _imprimirInventario();
    }

    private void _imprimirInventario()
    {
        foreach(string key in _almacenamiento.Keys)
        {
            Debug.Log("Objeto: " + key + ", Cantidad: " + _almacenamiento[key]);
        }
    }
}
