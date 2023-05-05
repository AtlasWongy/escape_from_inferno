using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Create a new quest")]
public class QuestBase : ScriptableObject
{
   [SerializeField] string QuestName;
   [SerializeField] string Description;
    
}
