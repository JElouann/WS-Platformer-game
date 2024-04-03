using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRoll : MonoBehaviour
{
    private PlayerInput _input;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody2D>();
        var inputManager = this.GetComponent<InputManager>();
        inputManager.Roll += this.Roll;
    }

    private void Roll(InputAction.CallbackContext context)
    {
        Debug.Log("WIYAAHAH");
        _rb.freezeRotation = false;
    }
}
