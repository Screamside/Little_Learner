using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Script.Events;
using Script.Items;
using UnityEditor;
using UnityEngine;

    public class Inventory : MonoBehaviour
    {
        
        [BoxGroup("Debug")] [SerializeField] private Item[] _inventoryList;
        [BoxGroup("Debug")] [SerializeField] [ReadOnly] private Item _selectedItem;

        public Item[] inventoryList
        {
            get => _inventoryList;
        }
        public Item selectedItem
        {
            get => _selectedItem;
            set
            {
                Database.Instance.EVENTS.OnPlayerChangeSelectedItem.Invoke(value);
                _selectedItem = value;
            }
        }

        private void Awake()
        {
            
        }

        public void Increase(int count)
        {
            Array.Resize(ref _inventoryList, _inventoryList.Length + count);
            Database.Instance.EVENTS.OnInventorySizeChanged.Invoke(_inventoryList);
        }

        public void Decrease(int count)
        {
            if (_inventoryList.Length > 0)
            {
                RemoveItem(_inventoryList.Length-1);
                Debug.Log(_inventoryList.Length - count);
                Database.Instance.EVENTS.OnInventorySizeChanged.Invoke(_inventoryList);
                Array.Resize(ref _inventoryList, _inventoryList.Length - count);
                
            }
            else
            {
                Debug.Log("Inventory has no space do decrease.");
            }
        }

        public void AddItem(Item item)
        {
            for (int i = 0; i < _inventoryList.Length; i++)
            {
                if (_inventoryList[i] is null)
                {
                    _inventoryList[i] = item;
                    Database.Instance.EVENTS.OnInventoryItemChanged.Invoke(_inventoryList, i);
                    return;
                }
            }
        }

        public void RemoveItem(int slot)
        {
            if (slot < _inventoryList.Length)
            {
                _inventoryList[slot] = null;
                Database.Instance.EVENTS.OnInventoryItemChanged.Invoke(_inventoryList, slot);
            }
        }
        
        [Button()]
        private void AddSlot()
        {
            Increase(1);
        }
        [Button()]
        private void RemSlot()
        {
            Decrease(1);
        }
        
        [Button()]
        private void AddItem()
        {
            AddItem(Database.Instance.TOOLS.AXE);
        }
        
    }
