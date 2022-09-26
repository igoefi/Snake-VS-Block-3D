using UnityEngine;
using TMPro;
public class Tablet : UsableObject
{

    [SerializeField] TMP_Text _text;

    private void Start()
    {
        _text.text = _count.ToString();
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
