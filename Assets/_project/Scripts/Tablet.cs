using UnityEngine;
using TMPro;
public class Tablet : UsableObject
{

    [SerializeField] TMP_Text _text;
    [SerializeField] AudioSource _audio;

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
        StartCoroutine(StartAudio());
        Destroy(gameObject);
    }
    private System.Collections.IEnumerator StartAudio()
    {
        _audio.Play();
        _audio.transform.parent = transform.parent;
        yield return new WaitForSeconds(1);
        Destroy(_audio);
    }
}
