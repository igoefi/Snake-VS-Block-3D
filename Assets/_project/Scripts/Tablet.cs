using UnityEngine;

public class Tablet : UsableObject
{
    [SerializeField] private int Sum;
    private void Start()
    {
        _count += Sum;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        PlayerBall player = other.GetComponent<PlayerBall>();
        if (player == null) return;
        if (player.IsHead == false) return;

        other.GetComponent<PlayerBall>().AddTail(_count);
        Destroy(gameObject);
    }
}
