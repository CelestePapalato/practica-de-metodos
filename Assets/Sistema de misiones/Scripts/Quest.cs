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
    [CreateAssetMenu(fileName = "Quest Data", menuName = "Quest System/Quest Data", order = 1)]
    public class Quest : ScriptableObject
    {
        [SerializeField]
        string _nombre;
        public string Nombre { get => _nombre; }
        [SerializeField]
        string _objetivo;
        public string Objetivo { get => _objetivo; }
        [SerializeField]
        TYPE _type;
        public TYPE Tipo { get => _type; }
    }
}