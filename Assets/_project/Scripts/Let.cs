using UnityEngine;
using TMPro;
using System.Collections;

public class Let : UsableObject
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] TMP_Text[] _texts;

    private void Start()
    {
        SetText();
    }

    protected override void OnTriggerEnter(Collider other)
    { 
        PlayerBall player = other.GetComponent<PlayerBall>();
        if (player == null) return;
        if (player.IsHead == false) return;

        player.Dead();
        _count--;

        if (_texts != null) SetText();
        if(_particleSystem != null) _particleSystem.Play();

        if (_count <= 0)
            StartCoroutine(Dead());
    }
    private void SetText()
    {
        foreach(TMP_Text text in _texts)
        {
            text.text = _count.ToString();
        }
    }
    private IEnumerator Dead()
    {
        if (_particleSystem != null) _particleSystem.transform.parent = transform.parent;
        Destroy(gameObject);
        yield return new WaitForSeconds(1);
        if (_particleSystem != null) Destroy(_particleSystem);
    }
}
