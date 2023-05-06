using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        private bool inventoryPressed;
        [SerializeField] private GameObject inventoryObject;
        private bool inventoryToggled = false;
        private static Inventory _instance;
        public Image[] inventorySlots;

        private void Awake()
        {
            if (_instance != null)
            {
                Debug.LogError("Found more than one Inventory Manager in the scene");
            }

            _instance = this;
        }

        private void Start()
        {
            inventoryObject.SetActive(false);
            for (int i = 0; i < inventoryObject.transform.GetChild(0).childCount; i++)
            {
                Transform slot = inventoryObject.transform.GetChild(0).GetChild(i);
                inventorySlots[i] = slot.GetChild(0).transform.GetComponent<Image>();
            }
        }

        public static Inventory GetInstance()
        {
            return _instance;
        }

        public void ToggleInventory(InputAction.CallbackContext context)
        {
            if (context.performed && !inventoryToggled)
            {
                inventoryToggled = true;
                inventoryObject.SetActive(inventoryToggled);
                inventoryPressed = true;
            }
            else if (context.performed && inventoryToggled)
            {
                inventoryToggled = false;
                inventoryObject.SetActive(inventoryToggled);
                inventoryPressed = true;
            }
            else if (context.canceled)
            {
                inventoryPressed = false;
            }
        }

        public void UpdateInventory(Image[] newInventorySlots)
        {
            inventorySlots = newInventorySlots;
            foreach (Image item in inventorySlots)
            {
                if (item.sprite != null)
                {
                    Color originalColor = item.color;
                    float newAlpha = 1.0f;
                    item.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                }
            }
        }
    }
}