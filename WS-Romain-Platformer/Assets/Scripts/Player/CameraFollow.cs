using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _objectToFollow;
    [SerializeField]
    private Vector3 _offset;
    [SerializeField]
    private float _smoothTime;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        Vector3 targetPosition = _objectToFollow.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, _smoothTime);
    }
}
