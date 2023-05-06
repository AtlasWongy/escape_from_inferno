using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    [CreateAssetMenu(menuName = "Item/Create a new item")]
    public class ItemBase : ScriptableObject
    {
        public string itemName;
        public Sprite itemSprite;

    }
}
