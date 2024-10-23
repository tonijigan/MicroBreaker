using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPanel : MonoBehaviour
{
    [SerializeField] private List<Panel> _panels;

    private AudioSource _audioSource;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    private void OnEnable()
    {
        foreach (var panel in _panels)
            panel.Moved += Play;
    }

    private void OnDisable()
    {
        foreach (var panel in _panels)
            panel.Moved -= Play;
    }

    private void Play() => _audioSource.Play();
}