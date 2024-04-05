using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public SO_PlayerData _data;
    
    private PlayerRoll _roll;

    public bool canRoll;
    public bool isRolling;

    [SerializeField]
    private AudioClip _music;

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

    private void Start()
    {
        SoundManager.Instance.PlayMusic(_music);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("wou");
    }
}
