using System.Linq;
using UnityEngine;

public class PanelSettings : Panel
{
    private const int MaxVolume = 1;
    private const int MinVolume = 0;

    [SerializeField] private ButtonSettingAudio _buttonSettingMusic;
    [SerializeField] private ButtonSettingAudio _buttonSettingEffect;
    [SerializeField] private Panel _backGround;

    private void Start()
    {
        LoadAudioSettings(_buttonSettingMusic);
        LoadAudioSettings(_buttonSettingEffect);
    }

    private void OnEnable()
    {
        _buttonSettingMusic.Changed += Save;
        _buttonSettingEffect.Changed += Save;
    }

    private void OnDisable()
    {
        _buttonSettingMusic.Changed -= Save;
        _buttonSettingEffect.Changed -= Save;
    }

    public override async void Move(bool isActive)
    {
        _backGround?.gameObject.SetActive(isActive);
        base.Move(isActive);
        await MovePanel(isActive);
    }

    private void LoadAudioSettings(ButtonSettingAudio buttonSettingAudio)
    {
        int value = PlayerPrefs.GetInt(buttonSettingAudio.AudioName.ToString());
        bool isEnable = value == MaxVolume;
        buttonSettingAudio.Init(isEnable);
    }

    private void Save(ButtonSettingAudio buttonSettingAudio)
    {
        int value = buttonSettingAudio.IsEnable ? MaxVolume : MinVolume;
        PlayerPrefs.SetInt(buttonSettingAudio.AudioName.ToString(), value);
    }
}