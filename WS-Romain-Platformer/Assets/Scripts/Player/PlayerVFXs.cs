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

    [SerializeField] private ParticleSystem _smokeTrailSystem;

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
        if (_rb.velocity.x < 0.1f && _rb.velocity.x > -0.1f)
        {
            //_smokeTrailSystem.gameObject.SetActive(false);
        }
        else if (_rb.velocity.x >= -0.1f)
        {
            _toStretch.transform.localScale = new Vector3(_rb.velocity.x / 50 + 1, _rb.velocity.y / 50 + 1);
            //_smokeTrailSystem.gameObject.SetActive(true);
        }
        else
        {
            _toStretch.transform.localScale = new Vector3(_rb.velocity.x / 50 - 1, _rb.velocity.y / 50 + 1);
            //_smokeTrailSystem.gameObject.SetActive(true);
        }

        if (_main.canRoll)
        {
            _smokeTrailSystem.gameObject.SetActive(true);
        }
        else
        {
            _smokeTrailSystem.gameObject.SetActive(false);
        }


    }

    public void SimpleScreenShake(float duration, float vibrato)
    {
        _camera.DOShakePosition(duration, vibrato);
    }
}

