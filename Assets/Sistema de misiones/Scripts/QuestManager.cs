using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace QuestSystem {
    public class QuestManager : MonoBehaviour
    {
        public static QuestManager instance;
        [SerializeField]
        private List<Quest> _misionesActivas = new List<Quest>();

        private void Awake()
        {
            instance = this;
        }

        public static UnityAction<Quest> nuevaMisionPrincipal;
        public static UnityAction<Quest> nuevaMisionSecundaria;
        private static void _nuevaMision(Quest quest)
        {
            if (nuevaMisionPrincipal != null && quest.Tipo == TYPE.Principal)
            {
                nuevaMisionPrincipal(quest);
            }
            if(nuevaMisionSecundaria != null && quest.Tipo == TYPE.Secundaria)
            {
                nuevaMisionSecundaria(quest);
            }
        }

        public static UnityAction<Quest> eliminarMisionPrincipal;
        public static UnityAction<Quest> eliminarMisionSecundaria;
        private static void _eliminarMision(Quest quest)
        {
            if (eliminarMisionPrincipal != null && quest.Tipo == TYPE.Principal)
            {
                eliminarMisionPrincipal(quest);
            }
            if (eliminarMisionSecundaria != null && quest.Tipo == TYPE.Secundaria)
            {
                eliminarMisionSecundaria(quest);
            }
        }

        public static void ActivarMision(Quest quest)
        {
            if (instance._misionesActivas.Contains(quest))
            {
                return;
            }
            instance._misionesActivas.Add(quest);
            _nuevaMision(quest);
        }

        public static void CancelarMision(Quest quest)
        {
            if (instance._misionesActivas.Contains(quest))
            {
                instance._misionesActivas.Remove(quest);
            }
            _eliminarMision(quest);
        }

        public static void CompletarMision(Quest quest)
        {
            if (instance._misionesActivas.Contains(quest))
            {
                instance._misionesActivas.Remove(quest);
            }
            _eliminarMision(quest);
        }
    }
}