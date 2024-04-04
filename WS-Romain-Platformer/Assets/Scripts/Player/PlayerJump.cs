using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private PlayerInput _input;
    private PlayerMain _main;
    private Rigidbody2D _rb;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private Transform groundCheckTransform;
    private Vector2 _groundCheckPoint;
    [SerializeField]
    private Vector2 _groundChezSize;
    //[SerializeField]
    //private float _coyoteTimeDuration;
    //private float _coyoteTimer;
    private bool _canJump;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _main = GetComponent<PlayerMain>();
        _rb = GetComponent<Rigidbody2D>();
        var inputManager = this.GetComponent<InputManager>();
        inputManager.Jump += this.Jump;
        //_coyoteTimer = _coyoteTimeDuration;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_canJump /*| _coyoteTimer > 0*/)
            {
                //_coyoteTimer = 0;
                _rb.velocity = new Vector2(_rb.velocity.x, 0);
                _rb.AddForce(Vector2.up * _main._data.JumpForce, ForceMode2D.Impulse);

                _canJump = false;
            }
        }
        if (context.canceled)
        {
            _rb.AddForce(Vector2.down * _rb.velocity.y * (1 - _main._data.JumpCutMultiplier), ForceMode2D.Impulse);
        }
    }

    /*private void Update()
    {
        Debug.Log(_coyoteTimer);
        _coyoteTimer -= Time.deltaTime;
    }*/

    private void FixedUpdate()
    {
        _groundCheckPoint = new Vector2(groundCheckTransform.position.x, groundCheckTransform.position.y);
        if (Physics2D.OverlapBox(_groundCheckPoint, _groundChezSize, 0))
        {
            //_coyoteTimer = _coyoteTimeDuration;
            _canJump = true;
        }
        else
        {
            _canJump = false;
        }
    }
}