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
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioName _audioName;

    public AudioSource AudioSource => _audioSource;
    public AudioName AudioName => _audioName;

    private bool _isEnanble;

    private void Start()
    {
        SetParameters();
    }

    protected override void OnClick()
    {
        _isEnanble = !_isEnanble;
        SetParameters();
    }

    private void SetParameters()
    {
        _audioSource.volume = _isEnanble ? MaxVolume : MinVolume;
        _text.text = _isEnanble ? StateDisable : StateEnable;
    }
}