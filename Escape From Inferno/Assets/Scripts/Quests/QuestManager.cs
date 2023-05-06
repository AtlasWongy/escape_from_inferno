using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Quests
{
    public class QuestManager : MonoBehaviour
    {
        private static QuestManager _instance;
        private List<Quest> questLists;

        private void Awake()
        {
            if (_instance != null)
            {
                Debug.LogWarning("Found more than one Quest Manager in the scene");
            }

            questLists = new List<Quest>();

            _instance = this;
        }

        public static QuestManager GetInstance()
        {
            return _instance;
        }

        private void Update()
        {
            if (Dialogue.DialogueManager.GetInstance().currentChoice == "ACCEPT")
            {
                AcceptQuest(Dialogue.DialogueManager.GetInstance().dialogueStarter.GetComponentInChildren<Quest>());
            }
        }

        private void AcceptQuest(Quest newQuest)
        {
            questLists.Add(newQuest);
        }
    }
}