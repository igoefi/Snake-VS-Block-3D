using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    [SerializeField] private Vector3 Indent;
    [SerializeField] private float ZSpeed;
    [SerializeField] private float MaxZSpeed;
    private bool _isHead = false;

    public Transform _nextPosition { get; set; }
    private Rigidbody _body;
    private void Start()
    {

        _body = GetComponent<Rigidbody>();
        if (transform.parent == null)
            _isHead = true;
    }

    private void Update()
    {
        Vector3 position = transform.position;

        if (_isHead)
        {
            _body.velocity += new Vector3(0, 0, ZSpeed * Time.deltaTime);
            if (_body.velocity.z > MaxZSpeed)
            {
                _body.velocity = new Vector3(_body.velocity.x, _body.velocity.y, MaxZSpeed);
            }
        }
        else
        {
            if (_nextPosition == null) return;

        }
    }

    public void AddTail(int sum)
    {
        Transform child = transform.GetChild(0);

        if (child != null)
            child.GetComponent<PlayerBall>().AddTail(sum);

    }

    private void SetHead()
    {
        _isHead = true;
    }
}
