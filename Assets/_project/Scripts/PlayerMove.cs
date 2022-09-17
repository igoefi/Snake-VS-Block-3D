using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float SpeedX;

    static public Vector3 HeadPositionX;

    private Vector3 _mousePosition;

    private void Update()
    {
        if(Input.mousePosition != _mousePosition)
        {
        }
    }
}
