using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    private PlayerMain _main;

    private PlayerVFXs _playerVFXs;
    
    private Rigidbody2D _rb;

    public SO_PlayerData _data;

    [SerializeField]
    private AudioClip _collisionSound;

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


        if (_lastFrameVelocity - _currentFrameVelocity > 52.5f || _lastFrameVelocity - _currentFrameVelocity < -52.5f)
        {
            if (!_screenShakePlayed)
            {
                _main.SwitchRollMode(false);
                SoundManager.Instance.PlaySound(_collisionSound);
                _playerVFXs.SimpleScreenShake(0.75f, (_lastFrameVelocity - _currentFrameVelocity) / 40);
                _screenShakePlayed = true;
            }
        }
        else
        {
            _screenShakePlayed = false;
        }

        if (_rb.velocity.x >= _main._data.TopSpeed || _rb.velocity.x <= -_main._data.TopSpeed)
        {
            //print("MAX SPEED");
        }
        else
        {
            //print("not max speed");
        }
    }
}