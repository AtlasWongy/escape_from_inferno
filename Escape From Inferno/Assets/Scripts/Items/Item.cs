using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {
        public ItemBase itemBase;
        public string itemName;

        public void Start()
        {
            itemName = itemBase.name;
        }

        private void Update()
        {
            if (Dialogue.DialogueManager.GetInstance().currentChoice == "YES") Destroy(transform.parent.gameObject);
        }
    }
}


