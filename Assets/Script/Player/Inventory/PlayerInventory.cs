using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Script.Events;
using Script.Input;
using Script.Items;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

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
                Database.Instance.EVENTS.OnPlayerChangeSelectedSlot.Invoke(_inventoryList, value);
                _selectedSlot = value;
            }
        }

        private void Awake()
        {
            
            InputManager.Instance.OnClientMouseScrollUp.AddListener(UpdateSelectedItemUp);
            InputManager.Instance.OnClientMouseScrollDown.AddListener(UpdateSelectedItemDown);
            Increase();
            
        }

        private void UpdateSelectedItemUp()
        {

            if (_selectedSlot == 0)
            {
                return;
            }

            _selectedSlot--;
            Database.Instance.EVENTS.OnPlayerChangeSelectedSlot.Invoke(_inventoryList, _selectedSlot);

        }

        private void UpdateSelectedItemDown()
        {

            if (_selectedSlot >= (_inventoryList.Length - 1))
            {
                return;
            }

            _selectedSlot++;
            Database.Instance.EVENTS.OnPlayerChangeSelectedSlot.Invoke(_inventoryList, _selectedSlot);

        }
        
        [Button()]
        public void Increase()
        {
            
            Array.Resize(ref _inventoryList, _inventoryList.Length+1);
            Database.Instance.EVENTS.OnInventorySizeChanged.Invoke(_inventoryList);
            
            if (_inventoryList.Length == 1)
            {
                Database.Instance.EVENTS.OnPlayerChangeSelectedSlot.Invoke(_inventoryList, _selectedSlot);
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
                Database.Instance.EVENTS.OnPlayerChangeSelectedSlot.Invoke(_inventoryList, _selectedSlot);
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
                    Database.Instance.EVENTS.OnPlayerChangeSelectedSlot.Invoke(_inventoryList, _selectedSlot);
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

        [Button()]
        private void Item()
        {

            var n = Random.Range(1, 4);
            

            switch (n)
            {
                
                case 1:
                    AddItem(Database.Instance.TOOLS.AXE);
                    break;
                    
                case 2:    
                    AddItem(Database.Instance.TOOLS.SWORD);
                    break;
                    
                case 3:    
                    AddItem(Database.Instance.TOOLS.PICKAXE);
                    break;
            }
            
        }
        
        
        
        
        
    }
