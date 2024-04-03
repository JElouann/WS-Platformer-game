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

    public void EnableTrail(bool enable)
    {
        if (enable)
        {
            _trail.enabled = true;
        }
        else
        {
            _trail.enabled = false;
        }
    }
}
