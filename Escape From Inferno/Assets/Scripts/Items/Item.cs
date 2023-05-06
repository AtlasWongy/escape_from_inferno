using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class Item : MonoBehaviour
    {
        public ItemBase itemBase;
        public string itemName;
        public Sprite itemSprite;
        public void Start()
        {
            itemName = itemBase.itemName;
            itemSprite = GetComponent<SpriteRenderer>().sprite = itemBase.itemSprite;
        }

        private void Update()
        {
            if (Dialogue.DialogueManager.GetInstance().currentChoice == "YES") AddToInventory();
        }

        private void AddToInventory()
        {
            // Add the icon here
            Image[] items = Inventory.Inventory.GetInstance().inventorySlots;
            foreach (Image item in items)
            {
                if (item.sprite == null)
                {
                    item.sprite = itemSprite;
                    break;
                }
            }
            Debug.Log($"The new sprite is added before sending to manager: {items[0].sprite}");
            Inventory.Inventory.GetInstance().UpdateInventory(items);
            Destroy(gameObject);
        }
    }
}


