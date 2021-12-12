using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame udate
    public float speed = 5f;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _lookDirection = Vector2.down;
    private Vector2 _currentInput;
    private float _x;
    private float _y;
    private Animator _animator;
    private int _maxHealth = 6;
    private int _currentHealth;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(_x, _y);
        if (!Mathf.Approximately(movement.x, 0.0f) || !Mathf.Approximately(movement.y, 0.0f))
        {
            _lookDirection.Set(movement.x, movement.y);
            _lookDirection.Normalize();
        }
        _animator.SetFloat("lookX",_lookDirection.x);
        _animator.SetFloat("lookY",_lookDirection.y);
        _animator.SetFloat("speed",movement.magnitude);

        _currentInput = movement;
    }

    private void FixedUpdate()
    {
        Vector2 position = _rigidbody2D.position;
        position += _currentInput * speed * Time.deltaTime;
        _rigidbody2D.MovePosition(position);
    }

    public void changeHealth(int value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, _maxHealth);
        print("current health: " + _currentHealth);
    }
}