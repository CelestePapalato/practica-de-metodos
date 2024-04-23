using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem {
    public class QuestManager : MonoBehaviour
    {
        [SerializeField]
        GridLayoutGroup _UIListaPrincipales;
        [SerializeField]
        GridLayoutGroup _UIListaSecundarias;

        static List<Quest> _misionesActivas = new List<Quest>();

        public static void ActivarMision(Quest quest)
        {
            if (_misionesActivas.Contains(quest))
            {
                return;
            }
            _misionesActivas.Add(quest);
        }

        public static void CancelarMision(Quest quest)
        {
            if (_misionesActivas.Contains(quest))
            {
                _misionesActivas.Remove(quest);
            }
        }

        public static void CompletarMision(Quest quest)
        {
            if (_misionesActivas.Contains(quest))
            {
                _misionesActivas.Remove(quest);
            }
        }
    }
}