using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Script.Input;
using Script.Tools;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTool : MonoBehaviour
{

    [SerializeField] [BoxGroup("References")] private GameObject _tool;
    [SerializeField] [BoxGroup("References")] private Animator _toolAnimator;
    [SerializeField] [BoxGroup("References")] private Camera _camera;
    
    public Vector3 lookPoint;
    public GameObject slash;
    
    private void Awake()
    {
        InputManager.Instance.OnClientMouseLeftClick.AddListener(Attack);
    }
    
    private void Attack()
    {
        Debug.Log("slashed?");
        Instantiate(slash, _tool.transform.position, _tool.transform.rotation);
        PlayAttackAnimation();
    }
    
    private void PlayAttackAnimation()
    {
        _toolAnimator.Play("Attack");
    }
    
    
    void LateUpdate()
    {
        
        lookPoint = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
        _tool.transform.rotation = Quaternion.RotateTowards(_tool.transform.rotation,Quaternion.LookRotation(Vector3.forward, -(transform.position - lookPoint).normalized ), 10);

    }
}