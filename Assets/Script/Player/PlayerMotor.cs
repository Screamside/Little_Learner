using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Script.Events;
using Script.Input;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{

    [SerializeField] [Foldout("Debug")] [ReadOnly] public PlayerBaseState _currentPlayerState;
    [SerializeField] [Foldout("Debug")] [ReadOnly] public Vector2 _currentDirection;
    [SerializeField] [Foldout("Debug")] [ReadOnly] public bool _isSprinting;
    [SerializeField] [Foldout("Debug")] [ReadOnly] public Vector2 _currentMousePositionScreen;

    [SerializeField] [Foldout("Debug")] [ReadOnly]
    private Vector2 _currentVelocity;

    [SerializeField] [Foldout("Movement")] public float MaxWalkSpeed;
    
    [SerializeField] [Foldout("References")] private Rigidbody2D _rigidbody2D;
    [SerializeField] [Foldout("References")] private Animator _animator;
    [SerializeField] [Foldout("References")] private SpriteRenderer _spriteRenderer;

    public PlayerStateList PlayerStateList;
    
    private void Awake()
    {
        PlayerStateList = new PlayerStateList(this);

        _currentPlayerState = PlayerStateList.GetState(PlayerStates.IDLE);
        
        InputManager.Instance.OnClientMove.AddListener(direction => _currentDirection = direction);
        InputManager.Instance.OnClientSprint.AddListener(isSprinting => _isSprinting = isSprinting);
    }

    private void Update()
    {
        _currentPlayerState.UpdateState();

        _currentVelocity = _rigidbody2D.velocity;

        FlipSprite();
        
    }

    private void FlipSprite()
    {
        float middle = Screen.width / 2;

        _spriteRenderer.flipX = !(Mouse.current.position.ReadValue().x > middle);
    }
    
    private void FixedUpdate()
    {
        _currentPlayerState.FixedUpdateState();
    }

    public void ChangePlayerState(PlayerStates state)
    {
        _currentPlayerState.ExitState();
        _currentPlayerState = PlayerStateList.GetState(state);
        _currentPlayerState.InitializeState();
    }

    public void MovePlayer(float speed)
    {

        _rigidbody2D.MovePosition(Vector2.MoveTowards(
            _rigidbody2D.position, 
            _rigidbody2D.position + _currentDirection, 
            speed * Time.deltaTime
            ));

    }

    public void ChangeAnimation(PlayerStates state)
    {

        switch (state)
        {
            
            case PlayerStates.IDLE:
                _animator.SetBool("IsWalking", false);
                break;
            
            case PlayerStates.WALK:
                _animator.SetBool("IsWalking", true);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
        
        
    }
    
}

public enum PlayerStates
{
    IDLE,
    WALK
}


