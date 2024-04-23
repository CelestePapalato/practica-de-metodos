using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public enum TYPE
    {
        Principal,
        Secundaria
    }

    public class Quest : ScriptableObject
    {
        string _nombre;
        public string Nombre { get => _nombre; }
        string _objetivo;
        public string Objetivo { get => _objetivo;}
        TYPE _type;
        public TYPE Tipo { get => _type; }
    }
}