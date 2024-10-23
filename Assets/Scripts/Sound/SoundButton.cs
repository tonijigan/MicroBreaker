using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundButton : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public AudioSource AudioSource => _audioSource;

    private void OnEnable()
    {
        foreach (var button in _buttons)
            button.onClick.AddListener(Play);
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
            button.onClick.RemoveListener(Play);
    }

    public void Play()
    {
        _audioSource.Play();
    }
}