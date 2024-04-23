using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem
{
    public class QuestLog : MonoBehaviour
    {
        [SerializeField]
        TYPE _tipoDeMisiones;
        [SerializeField]
        QuestUI _questUIPrefab;

        List<QuestUI> currentQuestUI = new List<QuestUI>();

        GridLayoutGroup grid;

        private void Awake()
        {
            grid = GetComponent<GridLayoutGroup>();
            if (!grid)
            {
                grid = GetComponentInChildren<GridLayoutGroup>();
            }

            switch (_tipoDeMisiones)
            {
                case TYPE.Principal:
                    {
                        QuestManager.nuevaMisionPrincipal += _añadirQuest;
                        QuestManager.eliminarMisionPrincipal += _eliminarQuest;
                        break;
                    }
                case TYPE.Secundaria:
                    {
                        QuestManager.nuevaMisionSecundaria += _añadirQuest;
                        QuestManager.eliminarMisionSecundaria += _eliminarQuest;
                        break;
                    }
            }
        }

        private void _añadirQuest(Quest quest)
        {
            if(!grid || !_questUIPrefab)
            {
                return;
            }
            QuestUI questToAdd = Instantiate(_questUIPrefab, grid.transform);
            questToAdd.QuestData = quest;
            currentQuestUI.Add(questToAdd);
        }

        private void _eliminarQuest(Quest quest)
        {
            if (!grid || !_questUIPrefab)
            {
                return;
            }
            foreach(QuestUI questUI in currentQuestUI)
            {
                if(questUI.QuestData == quest)
                {
                    currentQuestUI.Remove(questUI);
                    Destroy(questUI.gameObject);
                    return;
                }
            }
        }
    }
}