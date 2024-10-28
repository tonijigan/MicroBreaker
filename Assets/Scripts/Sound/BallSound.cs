using BallObject;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BallSound : MonoBehaviour
{
    [SerializeField] private BallMovement _ballMovement;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _ballMovement.BallTriggered += Play;
    }

    private void OnDisable()
    {
        _ballMovement.BallTriggered -= Play;
    }

    private void Play(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
}