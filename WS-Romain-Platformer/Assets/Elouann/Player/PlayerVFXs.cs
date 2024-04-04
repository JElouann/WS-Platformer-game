using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerVFXs : MonoBehaviour
{
    private Camera _camera;
    private TrailRenderer _trail;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _camera = Camera.main;
        _trail = GetComponent<TrailRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SimpleScreenShake(float duration, float vibrato)
    {
        _camera.DOShakePosition(duration, vibrato);
    }

    public void IsLongTrail(bool isLong)
    {
        if (isLong)
        {
            _trail.time = 0.08f;
        }
        else
        {
            _trail.time = 0.03f;
        }
    }
}
