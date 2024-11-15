using UnityEngine;

public class SoundAction : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource[] _audioSources;

    private void Awake()
    {
        _audioSourceMusic.volume = PlayerPrefs.GetFloat(Enums.AudioName.Music.ToString());
        float currentValue = PlayerPrefs.GetFloat(Enums.AudioName.Effect.ToString());

        foreach (AudioSource audioSource in _audioSources) audioSource.volume = currentValue;
    }
}