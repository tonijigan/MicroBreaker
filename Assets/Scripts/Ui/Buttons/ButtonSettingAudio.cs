using Enums;
using System;
using TMPro;
using UnityEngine;

public class ButtonSettingAudio : AbstractButton
{
    private const int MinVolume = 0;
    private const int MaxVolume = 1;
    private const string StateEnable = "On";
    private const string StateDisable = "Off";

    [SerializeField] private TMP_Text _text;
    [SerializeField] private AudioName _audioName;
    [SerializeField] private AudioSource[] _audioSources;

    public event Action<ButtonSettingAudio> Changed;

    private bool _isEnable;

    public AudioName AudioName => _audioName;

    public AudioSource[] AudioSources => _audioSources;

    public void Init(bool isEnable)
    {
        _isEnable = isEnable;
        SetParameters(isEnable);
    }

    protected override void OnClick()
    {
        _isEnable = !_isEnable;
        SetParameters(_isEnable);
        Changed?.Invoke(this);
    }

    public void SetParameters(bool isEnable)
    {
        foreach (var audioSource in _audioSources)
        {
            audioSource.volume = isEnable ? MaxVolume : MinVolume;
            _text.text = isEnable ? StateEnable : StateDisable;
        }
    }
}