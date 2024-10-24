using UnityEngine;

public class SoundAction : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource[] _audioSources;

    private void Awake()
    {
        _audioSourceMusic.volume = PlayerPrefs.GetInt(Enums.AudioName.Music.ToString());
        int currentValue = PlayerPrefs.GetInt(Enums.AudioName.Effect.ToString());

        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.volume = currentValue;
        }
    }
}