using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSong : MonoBehaviour
{
    [SerializeField] AudioClip[] Clips;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();

        System.Random rand = new();
        _audio.clip = Clips[rand.Next(0, Clips.Length)];

        _audio.Play();
    }
}
