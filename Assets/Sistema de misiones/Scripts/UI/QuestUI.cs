using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace QuestSystem
{
    public class QuestUI : MonoBehaviour
    {
        Quest questData;
        public Quest QuestData
        {
            get { return questData; }

            set
            {
                questData = value;
                _actualizarDatos(questData);
            }
        }

        [SerializeField]
        TMP_Text nombre;
        [SerializeField]
        TMP_Text objetivo;

        void _actualizarDatos(Quest quest)
        {
            if (nombre)
            {
                nombre.text = quest.Nombre;
            }
            if (objetivo)
            {
                objetivo.text = quest.Objetivo;
            }
        }
    }
}