using System;
using NaughtyAttributes;
using Script.Input;
using Script.Items;
using UnityEngine;
using UnityEngine.InputSystem;

    [Serializable]
    public class PlayerHand
    {
        
        public Item itemInHand
        {
            get => _itemInHand;
            set
            {
                _slotSpriteRenderer.sprite = value.Sprite;
                _itemInHand = value;
            }
        }

        [SerializeField] [BoxGroup("References")] private SpriteRenderer _slotSpriteRenderer;
        [SerializeField] [BoxGroup("References")] private Animator _handAnimator;
        [SerializeField] [BoxGroup("References")] private Transform _slotTransform;
        [SerializeField] [BoxGroup("References")] private Transform _playerHand;

        private bool _isAttacking = false;
        private Camera _camera;
        [SerializeField] private Item _itemInHand;

        public void Initialize()
        {
            _camera = Database.Instance.MAIN_CAMERA;
            
            InputManager.Instance.OnClientMouseLeftClick.AddListener(PlayAttackAnimation);
        }

        private void PlayAttackAnimation()
        {
            
            if(_isAttacking) {return;}
            
            _isAttacking = true;
            _handAnimator.Play("Attack");
            
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
