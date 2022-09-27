using System.Collections;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    [SerializeField] private Vector3 Indent;
    [SerializeField] private float IndentSmooth;

    [SerializeField] private float ZSpeed;
    [SerializeField] private float XSpeed;
    [SerializeField] private float MaxZSpeed;

    [SerializeField] private float minXPos;
    [SerializeField] private float maxXPos;

    [SerializeField] private ParticleSystem _finishParticles;
    [SerializeField] AudioSource _finishAudio;
    public bool IsHead { get; private set; } = false;
    public Vector3 NextPosition { get; set; }

    public static int SumOfShips { get; private set; }

    private PlayerBall _parent;
    private Rigidbody _body;

    private bool _isFinish;
    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        Transform parent = transform.parent;
        if (parent == null)
        {
            IsHead = true;
            CameraFollow.HeadBall = transform;
            SumOfShips = 1;
        }
        else
        {
            SumOfShips++;
            _parent = parent.GetComponent<PlayerBall>();
        }
    }

    private void Update()
    {
        if (GameManager.GameState != GameManager.GameStates.Playing)
        {
            if (GameManager.GameState == GameManager.GameStates.Win && !_isFinish)
            {
                _isFinish = true;
                StartCoroutine(Finish());
            }

            _body.velocity = Vector3.zero;
            return;
        }

        NextPosition = transform.position;

        if (IsHead)
        {
            HeadMove();
        }
        else
        {
            if (NextPosition == null) return;

            Vector3 dif = _parent.transform.position - Indent - transform.position;
            _body.MovePosition(transform.position + dif * IndentSmooth);
        }
    }

    public void AddTail(int sum)
    {
        if (transform.childCount > 2)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.GetComponent<PlayerBall>() != null)
                {
                    child.GetComponent<PlayerBall>().AddTail(sum);

                }
            }
            return;
        }

        GameObject ball = Instantiate(gameObject, transform);

        sum--;
        if (sum > 0)
            ball.GetComponent<PlayerBall>().AddTail(sum);
    }

    public void SetHead(Vector3 velocity)
    {
        IsHead = true;
        _parent = null;

        _body.velocity = velocity * 0.7f;

        CameraFollow.HeadBall = transform;
    }

    public void Dead()
    {
        FlashHead();
        SumOfShips--;
        Destroy(gameObject);
    }

    private void FlashHead()
    {
        if (transform.childCount <= 2)
        {
            GameManager.SetGameState(GameManager.GameStates.Lose);
            return;
        }

        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<PlayerBall>() != null)
            {
                child.gameObject.GetComponent<PlayerBall>().SetHead(_body.velocity);
                child.gameObject.GetComponent<PlayerBall>().enabled = true;
                child.transform.parent = null;
                return;
            }
        }

    }

    private void HeadMove()
    {
        Vector3 velocity = new(PlayerBias.HeadVelocityX * XSpeed * Time.deltaTime, 0, ZSpeed * Time.deltaTime);
        _body.velocity += velocity;

        if (_body.velocity.z > MaxZSpeed)
        {
            _body.velocity = new(_body.velocity.x, _body.velocity.y, MaxZSpeed);
        }

        if (Input.GetMouseButtonUp(0))
            _body.velocity = new(0, _body.velocity.y, _body.velocity.z);

        Vector3 pos = transform.position;
        if (pos.x > minXPos && pos.x < maxXPos) return;

        if (pos.x > maxXPos)
            pos = new(maxXPos - .1f, pos.y, pos.z);
        else if (pos.x < minXPos)
            pos = new(minXPos + .1f, pos.y, pos.z);

        transform.position = pos;
        _body.velocity = new(0, _body.velocity.y, _body.velocity.z);
    }

    private IEnumerator Finish()
    {
        _finishParticles.Play();

        _finishParticles.transform.parent = transform.parent;
        _finishAudio.transform.parent = transform.parent;

        yield return new WaitForSeconds(.7f);

        Destroy(gameObject);
        if(_parent == null)
            _finishAudio.Play();

        yield return new WaitForSeconds(4.3f);

        Destroy(_finishParticles);
        if(_parent == null)
            Destroy(_finishAudio);
    }
}
