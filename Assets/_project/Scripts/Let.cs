using UnityEngine;

public class Let : UsableObject
{
    [SerializeField] private int Sum;

    private void Start()
    {
        _count = Sum;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        PlayerBall player = other.GetComponent<PlayerBall>();
        if (player == null) return;
        if (player.IsHead == false) return;
        if (player.IsHead == false) return;

        player.Dead();
        _count--;
        if (_count <= 0)
            Destroy(gameObject);
    }
}
