using System;
using NaughtyAttributes;
using Script.Items;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.Player
{
    public class PlayerStats : MonoBehaviour
    {

        [SerializeField] [BoxGroup("Inventory")] private Inventory _playerInventory;
        [SerializeField] [BoxGroup("Inventory")] private PlayerHand _playerHand;

        private void Awake()
        {
            _playerHand.Initialize();
            AddItem(global::Database.Instance.TOOLS.AXE);
            
        }

        public void AddItem(Item item)
        {
            _playerInventory.AddItemToInventory(item);
            _playerHand.itemInHand = item;
        }

        public void ResetAttackAnimation()
        {
            
            Debug.Log("got here");
            
            _playerHand.ResetAttackAnimation();
        }

        private void LateUpdate()
        {
            _playerHand.Update();
        }
    }
}