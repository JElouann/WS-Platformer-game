using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerVFXs : MonoBehaviour
{
    private Camera _camera;
    private TrailRenderer _trail;
    private Rigidbody2D _rb;
    private PlayerMain _main;

    private void Awake()
    {
        _camera = Camera.main;
        _trail = GetComponent<TrailRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _main = GetComponent<PlayerMain>();

    }

    public void SimpleScreenShake(float duration, float vibrato)
    {
        _camera.DOShakePosition(duration, vibrato);
    }

    
}

