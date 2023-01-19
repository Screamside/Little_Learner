using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Script.Items;
using UnityEditor;
using UnityEngine;

    [Serializable]
    public class Inventory
    {

        [SerializeField] public int _inventorySize;
        [SerializeField] [ReadOnly] private Item[] _inventoryList;
        [SerializeField] public int _hotbarSize;
        [SerializeField] [ReadOnly] private Item[] _hotbarList;

        private Inventory()
        {

            _inventoryList = new Item[_inventorySize];
            _hotbarList = new Item[_hotbarSize];
            

        }

        public void PopulateHUD()
        {
            
        }
        
        public bool AddItemToInventory(Item item)
        {
            
            for (int i = 0; i > _inventorySize; i++)
            {
                if (_inventoryList[i].Equals(null))
                {   
                    //inventory has space so return true
                    _hotbarList[i] = item;
                    return true;
                }
            }
            
            Debug.Log("Inventory is full.");
            
            //inventory has no space so return false;
            return false;
        }

        private bool AddItemToHotbar(Item item)
        {
            
            UIManager.Instance._viewHUD.AddItem(item);
            
            for (var i = 0; i > _hotbarSize; i++)
            {
                if (_hotbarList[i].Equals(null))
                {   
                    //hotbar has space so return true
                    _hotbarList[i] = item;
                    return true;
                }
            }
            
            Debug.Log("Hotbar is full.");
            
            //hotbar has no space so return false;
            return false;

        }

    }
