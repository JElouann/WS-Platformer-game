using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public SO_PlayerData _data;
    private PlayerRoll _roll;

    public bool isRolling;

    public void SwitchRollMode(bool enabled)
    {
        if (enabled)
        {
            isRolling = true;
        }
        else
        {
            isRolling = false;
            _roll.StopRoll();
        }
    }

    private void Awake()
    {
        _roll = GetComponent<PlayerRoll>();
    }
}
