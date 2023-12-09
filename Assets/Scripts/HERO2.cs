using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HERO2 : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sp;
    private Animator _anim;

    private Vector2 _moveVector;
    private int _speed = 3;

    private int _jumpForce = 5;

    public LayerMask Ground;
    public Transform GroundCheck;
    private float _groundCheckRadius = 0.3f;
    private bool _onGround;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _groundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
    }

    private void Update()
    {
        Walk();
        Jump();
        CheckingGround();
    }

    private void Walk()
    {
        _moveVector.x = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_moveVector.x * _speed, _rb.velocity.y);
        _anim.SetFloat("MoveX", Mathf.Abs(_moveVector.x));

        _sp.flipX = _moveVector.x < 0;
    }

    private void Jump()
    {
        if (_onGround && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    private void CheckingGround()
    {
        _onGround = Physics2D.OverlapCircle(GroundCheck.position, _groundCheckRadius, Ground);
    }
}
