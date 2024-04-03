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
    private PlayerMain _main;

    private Rigidbody2D _rb;

    
    public SO_PlayerData _data;

    private PlayerVFXs _playerVFXs;
    private float _lastFrameVelocity;
    private float _currentFrameVelocity;
    private bool _screenShakePlayed;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _main = GetComponent<PlayerMain>();
        _rb = GetComponent<Rigidbody2D>();
        var inputManager = this.GetComponent<InputManager>();
        _playerVFXs = GetComponent<PlayerVFXs>();
    }

    private void FixedUpdate()
    {
        _lastFrameVelocity = _currentFrameVelocity;
        _currentFrameVelocity = _rb.velocity.x;

        var dir = this._input.actions.FindAction("Movement").ReadValue<Vector2>();
        float targetSpeed = dir.x * _main._data.TopSpeed;
        float speedDif = targetSpeed - _rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? _main._data.Acceleration : _main._data.Decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, _main._data.VelPower) * Mathf.Sign(speedDif);
        _rb.AddForce(movement * Vector2.right);

        if (_lastFrameVelocity - _currentFrameVelocity > 20)
        {
            if (!_screenShakePlayed)
            {
                _playerVFXs.SimpleScreenShake(0.75f, (_lastFrameVelocity - _currentFrameVelocity) / 50);
                _screenShakePlayed = true;
            }
        }
        else
        {
            _screenShakePlayed = false;
        }
    }
}