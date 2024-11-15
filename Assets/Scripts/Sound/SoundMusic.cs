using DG.Tweening;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundMusic : MonoBehaviour
{
    private const float MaxVolume = 1;
    private const float MinVolume = 0;
    private const float Duration = 1;

    private AudioSource _audioSource;
    private Coroutine _coroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
        SetActive(true);
    }

    public void SetActive(bool isEnable)
    {
        float volume = isEnable ? MaxVolume : MinVolume;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(PlayFade(volume));
    }

    private IEnumerator PlayFade(float voleme)
    {
        while (_audioSource.volume != voleme)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, voleme, Duration * Time.deltaTime);
            yield return null;
        }
    }
}