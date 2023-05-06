using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
    public class Quest : MonoBehaviour
    {
        public QuestBase quest;
        public int questID { get; private set; }
        public string questDesc { get; private set; }
        public string questProvider { get; private set; }
        public bool objectiveCompleted { get; private set; }

        private void Start()
        {
            questID = quest.questID;
            questDesc = quest.questDescription;
            questProvider = quest.questProvider;
            objectiveCompleted = quest.objectiveComplete;
        }

        private void Update()
        {
            if (objectiveCompleted)
            {
                Debug.Log("Quest is completed!");
            }
        }
    }
}
