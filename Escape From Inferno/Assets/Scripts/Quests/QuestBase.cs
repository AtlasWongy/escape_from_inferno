using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
    [CreateAssetMenu(menuName = "Quest/Create a new quest")]
    public class QuestBase : ScriptableObject
    {
        public int questID;
        public string questProvider;
        public string questDescription;
        public bool objectiveComplete = false;
    }
}