using System.Collections.Generic;
using UnityEngine;
using Extensions;

[RequireComponent(typeof(AudioSource))]
public class PlayRandomAudio : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _clips;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _audioSource.clip = _clips.GetRandomElement();
        _audioSource.Play();
    }

    private void OnDisable()
    {
        _audioSource.Stop();
    }
}
