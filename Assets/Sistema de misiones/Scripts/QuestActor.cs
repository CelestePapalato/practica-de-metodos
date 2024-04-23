using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {
    public class QuestActor : MonoBehaviour
    {
        [SerializeField]
        bool callQuestManagerOnStart = false;
        [SerializeField]
        List<Quest> _questsToActivate = new List<Quest>();
        [SerializeField]
        List<Quest> _questsToCancel = new List<Quest>();
        [SerializeField]
        List<Quest> _questsToComplete = new List<Quest>();

        private void Start()
        {
            if (callQuestManagerOnStart)
            {
                callQuestManager();
            }
        }

        private void OnMouseDown()
        {
            callQuestManager();
        }

        void callQuestManager()
        {
            foreach(Quest quest in _questsToActivate)
            {
                QuestManager.ActivarMision(quest);
            }
            foreach(Quest quest in _questsToCancel)
            {
                QuestManager.CancelarMision(quest);
            }
            foreach(Quest quest in _questsToComplete)
            {
                QuestManager.CompletarMision(quest);
            }
            Destroy(gameObject);
        }
    }
}