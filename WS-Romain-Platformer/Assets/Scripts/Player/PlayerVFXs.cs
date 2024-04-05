using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting;

public class PlayerVFXs : MonoBehaviour
{
    private Camera _camera;
    private TrailRenderer _trail;
    private Rigidbody2D _rb;
    private PlayerMain _main;

    [SerializeField] private GameObject _toStretch;
    [SerializeField] private GameObject _toRotate;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Color _blinkColor;

    private void Awake()
    {
        _camera = Camera.main;
        _trail = GetComponent<TrailRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _main = GetComponent<PlayerMain>();

    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        _toStretch.transform.localScale = new Vector3(_rb.velocity.x / 30 + 1, _rb.velocity.y / 50 + 1);
    }

    public void SimpleScreenShake(float duration, float vibrato)
    {
        _camera.DOShakePosition(duration, vibrato);
    }
}

