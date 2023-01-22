using System;
using NaughtyAttributes;
using Script.Input;
using Script.Items;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

    public class PlayerHand : MonoBehaviour
    {
        
        [SerializeField] private Item _itemInHand;
        public Item itemInHand
        {
            get => _itemInHand;
            set
            {
                _slotSpriteRenderer.sprite = value.Sprite;
                _itemInHand = value;
            }
        }

        [SerializeField] [BoxGroup("References")] private Transform _slot;
        [SerializeField] [BoxGroup("References")] private Transform _playerHand;


        private SpriteRenderer _slotSpriteRenderer;
        private Animator _slotAnimator;
        
        private bool _isAttacking = false;
        private Camera _camera;
        


        private void Awake()
        {
            _camera = Database.Instance.MAIN_CAMERA;
            _slotSpriteRenderer = _slot.GetComponent<SpriteRenderer>();
            _slotAnimator = _slot.GetComponent<Animator>();
            
            InputManager.Instance.OnClientMouseLeftClick.AddListener(PlayAttackAnimation);
            
            Database.Instance.EVENTS.OnPlayerChangeSelectedSlot.AddListener(UpdateHandItemSprite);
        }

        private void UpdateHandItemSprite(Item[] inventory, int slot)
        {

            if (inventory[slot] is null)
            {
                _slotSpriteRenderer.sprite = null;
                return;
            }
            
            _slotSpriteRenderer.sprite = inventory[slot].Sprite;
            
        }

        private void PlayAttackAnimation()
        {
            
            if(_isAttacking) {return;}
            
            _isAttacking = true;
            _slotAnimator.Play("Attack");
            
        }
        
        public void ResetAttackAnimation()
        {
            _isAttacking = false;
        }

        public void Update()
        {
            
            Vector3 lookPoint = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            
            _playerHand.rotation = Quaternion.RotateTowards(
                _playerHand.transform.rotation,
                Quaternion.LookRotation(Vector3.forward, -(_playerHand.position - lookPoint).normalized ), 
                10);
            
        }
        
    }
