using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _objectToFollow;
    [SerializeField]
    private float _delay;
    private bool _isDeactivate;

    private void Start()
    {
        StartCoroutine(Follow(_delay));
    }

    private IEnumerator Follow(float delay)
    {
        while (!_isDeactivate)
        {
            yield return new WaitForSeconds(delay);
            gameObject.transform.position = _objectToFollow.position;
        }
    }
}
