using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerVFXs : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        
    }

    public void SimpleScreenShake(float duration, float vibrato)
    {
        _camera.DOShakePosition(duration, vibrato);
    }
}
