using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

namespace Quests
{
    public class QuestBase : ScriptableObject
    {
        [System.Serializable]
        public struct Info
        {
            public string questName;
            public string description;
        }

        [Header("Info")] public Info information;

        public bool Completed { get; protected set; }
        public QuestCompleteEvent QuestCompleted;

        public abstract class QuestGoal : ScriptableObject
        {
            protected string description;
            public int currentAmount { get; protected set; }
            public int requiredAmount = 1;

            public bool Completed { get; protected set; }
            [HideInInspector] public UnityEvent GoalCompleted;

            public virtual string GetDescription()
            {
                return description;
            }

            public virtual void Initialize()
            {
                Completed = false;
                GoalCompleted = new UnityEvent();
            }

            protected void Evaluate()
            {
                if (currentAmount >= requiredAmount)
                {
                    Complete();
                }
            }

            private void Complete()
            {
                Completed = true;
                GoalCompleted.Invoke();
                GoalCompleted.RemoveAllListeners();
            }

            public void Skip()
            {
                Complete();
            }
        }

        public List<QuestGoal> Goals;

        public void Initialize()
        {
            Completed = false;
            QuestCompleted = new QuestCompleteEvent();

            foreach (var goal in Goals)
            {
                goal.Initialize();
                goal.GoalCompleted.AddListener(delegate { CheckGoals(); });
            }
        }

        private void CheckGoals()
        {
            Completed = Goals.TrueForAll(g => g.Completed);
            if (Completed)
            {
                QuestCompleted.Invoke(this);
                QuestCompleted.RemoveAllListeners();
            }
        }
    }

    public class QuestCompleteEvent : UnityEvent<QuestBase>
    {
    }
    
    #if UNITY_EDITOR
    [CustomEditor(typeof(QuestBase))]
    public class QuestEditor : Editor
    {
        
    }
    #endif
}