using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    private Rigidbody2D _rb;

    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _acceleration;
    [SerializeField]
    private float _decceleration;
    [SerializeField]
    private float _velPower;
    private PlayerVFXs _playerVFXs;
    private float _lastFrameVelocity;
    private float _currentFrameVelocity;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody2D>();
        var inputManager = this.GetComponent<InputManager>();
        _playerVFXs = GetComponent<PlayerVFXs>();
    }

    private void FixedUpdate()
    {
        var dir = this._input.actions.FindAction("Movement").ReadValue<Vector2>();
        //this._rb.velocity = new Vector2(dir.x * this._moveSpeed, _rb.velocity.y);

        float targetSpeed = dir.x * _moveSpeed;
        float speedDif = targetSpeed - _rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? _acceleration : _decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, _velPower) * Mathf.Sign(speedDif);
        _rb.AddForce(movement * Vector2.right);

        if (_rb.velocity.x == 0)
        {
            _playerVFXs.SimpleScreenShake(0.75f, 1);
        }
    }
}