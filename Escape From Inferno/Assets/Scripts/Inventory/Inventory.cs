using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        private bool inventoryPressed;
        [SerializeField] private GameObject InventoryObject;
        private static Inventory instance;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Found more than one Inventory Manager in the scene");
            }

            instance = this;
        }

        private void Start()
        {
            InventoryObject.SetActive(false);
        }

        public static Inventory GetInstance()
        {
            return instance;
        }

        public void ToggleInventory(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                InventoryObject.SetActive(true);
                inventoryPressed = true;
            }
            else if (context.canceled)
            {
                inventoryPressed = false;
            }
        }
    }
}