using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEffect : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    public float Speed;
    
    
    // Start is called before the first frame update
    void Awake()
    {

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        

    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = transform.up * Speed;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
