using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRoll : MonoBehaviour
{
    private PlayerInput _input;
    private Rigidbody2D _rb;

    private PlayerMain _playerMain;

    [SerializeField]
    private SO_PlayerData _playerNormalStateData;
    [SerializeField]
    private SO_PlayerData _playerRollStateData;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody2D>();
        var inputManager = this.GetComponent<InputManager>();
        inputManager.Roll += this.Roll;
        _playerMain = GetComponent<PlayerMain>();
    }

    private void Roll(InputAction.CallbackContext context)
    {
        if (_playerMain.isRolling)
        {
            _playerMain.isRolling = false;
            _playerMain._data = _playerNormalStateData;
        }
        else
        {
            if (_rb.velocity.x >= _playerMain._data.TopSpeed || _rb.velocity.x <= -_playerMain._data.TopSpeed)
            {
                _playerMain.isRolling = true;
                _playerMain._data = _playerRollStateData;
            }
        }
    }

    public void StopRoll()
    {
        _playerMain.isRolling = false;
        _playerMain._data = _playerNormalStateData;
    }
}

