using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CircleCollider2D))]
public class HERO : MonoBehaviour
{
    const string MoveX = "MoveX";
    const string Horizontal = "Horizontal";
    const int Speed = 3;
    const int JumpForce = 5;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private Vector2 _moveVector;

    public LayerMask Ground;
    public Transform GroundCheck;
    private float _groundCheckRadius = 0.3f;
    private bool _onGround;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
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
        _moveVector.x = Input.GetAxisRaw(Horizontal);
        _rigidBody.velocity = new Vector2(_moveVector.x * Speed, _rigidBody.velocity.y);
        _animator.SetFloat(MoveX, Mathf.Abs(_moveVector.x));

        _spriteRenderer.flipX = _moveVector.x < 0;
    }

    private void Jump()
    {
        if (_onGround && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, JumpForce);
        }
    }

    private void CheckingGround()
    {
        _onGround = Physics2D.OverlapCircle(GroundCheck.position, _groundCheckRadius, Ground);
    }
}
