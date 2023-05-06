using System.Collections;
using System.Collections.Generic;
using Quests;
using UnityEngine;

namespace Goals
{
    public class FetchingGoal : QuestBase.QuestGoal
    {
        public string Item;

        public override string GetDescription()
        {
            return $"Fetch {Item}";
        }

        public override void Initialize()
        {
            base.Initialize();
            EventManager.Instance.AddListener<FetchingGameEvent>(OnFetching);
        }

        public void OnFetching(FetchingGameEvent eventInfo)
        {
            if (eventInfo.ItemName == Item)
            {
                currentAmount++;
                Evaluate();
            }
        }
    }
}