using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static Transform HeadBall { get; set; }
    [SerializeField] Vector3 Indent;

    private Vector3 _lastPosition;

    private bool _isFirstStart = true;
    private void Update()
    {
        if (HeadBall == null) return;

        if (_lastPosition.z < HeadBall.position.z || _isFirstStart)
        {
            _lastPosition = HeadBall.position;
            _isFirstStart = false;
        }

        transform.position = new(transform.position.x, _lastPosition.y - Indent.y, _lastPosition.z - Indent.z);
    }
}
