using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class SO_PlayerData : ScriptableObject
{
    [Header("Run stats")]
    public float TopSpeed;
    public float Acceleration;
    public float Decceleration;
    public float VelPower;

    [Header("Jump stats")]
    public float JumpForce;
    public float JumpCutMultiplier;
}
