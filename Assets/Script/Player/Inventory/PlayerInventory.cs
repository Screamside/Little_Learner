using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Script.Events;
using Script.Input;
using Script.Items;
using UnityEditor;
using UnityEngine;

    public class PlayerInventory : MonoBehaviour
    {
        
        [BoxGroup("Debug")] [SerializeField] private Item[] _inventoryList;
        [BoxGroup("Debug")] [SerializeField] [ReadOnly] private int _selectedSlot;

        public Item[] inventoryList
        {
            get => _inventoryList;
        }
        public int selectedSlot
        {
            get => _selectedSlot;
            set
            {
                Database.Instance.EVENTS.OnPlayerChangeSelectedSlot.Invoke(value);
                _selectedSlot = value;
            }
        }

        private void Awake()
        {
            
            InputManager.Instance.OnClientMouseScrollUp.AddListener(UpdateSelectedItemUp);
            InputManager.Instance.OnClientMouseScrollDown.AddListener(UpdateSelectedItemDown);
            
        }

        private void UpdateSelectedItemUp()
        {

            if (_selectedSlot == 0)
            {
                return;
            }

            _selectedSlot--;
            Database.Instance.EVENTS.OnPlayerChangeSelectedSlot.Invoke(_selectedSlot);

        }

        private void UpdateSelectedItemDown()
        {

            if (_selectedSlot >= (_inventoryList.Length - 1))
            {
                return;
            }

            _selectedSlot++;
            Database.Instance.EVENTS.OnPlayerChangeSelectedSlot.Invoke(_selectedSlot);

        }
        
        [Button()]
        public void Increase()
        {
            
            Array.Resize(ref _inventoryList, _inventoryList.Length+1);
            Database.Instance.EVENTS.OnInventorySizeChanged.Invoke(_inventoryList);
            
            if (_inventoryList.Length == 1)
            {
                Database.Instance.EVENTS.OnPlayerChangeSelectedSlot.Invoke(_selectedSlot);
            }
            
        }
        
        [Button()]
        public void Decrease()
        {
            if (_inventoryList.Length > 1)
            {
                RemoveItem(_inventoryList.Length-1);
                Array.Resize(ref _inventoryList, _inventoryList.Length-1);
                Database.Instance.EVENTS.OnInventorySizeChanged.Invoke(_inventoryList);
            }
            else
            {
                Debug.Log("Inventory has no space do decrease.");
            }

            if (_selectedSlot > (_inventoryList.Length-1))
            {
                _selectedSlot = _inventoryList.Length-1;
                Database.Instance.EVENTS.OnPlayerChangeSelectedSlot.Invoke(_selectedSlot);
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
            
            Debug.Log("Inventory is full.");
        }

        public void RemoveItem(int slot)
        {
            if (slot < _inventoryList.Length)
            {
                _inventoryList[slot] = null;
                Database.Instance.EVENTS.OnInventoryItemChanged.Invoke(_inventoryList, slot);
            }
        }
        
        
        
        
        
    }
