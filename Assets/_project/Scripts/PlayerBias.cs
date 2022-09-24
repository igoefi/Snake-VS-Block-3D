using UnityEngine;

public class PlayerBias : MonoBehaviour
{
    public static float HeadVelocityX { get; private set; }

    private Vector3 _lastMousePosition;

    private void Update()
    {
        HeadVelocityX = 0;

        if (Input.GetMouseButtonDown(0))
            _lastMousePosition = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _lastMousePosition;
            HeadVelocityX = delta.x;
        }

        _lastMousePosition = Input.mousePosition;
    }
}
