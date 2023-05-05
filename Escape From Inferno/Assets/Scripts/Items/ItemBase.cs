using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Item/Create a new item")]
    public class ItemBase : ScriptableObject
    {
        public string itemName;
    }
}
