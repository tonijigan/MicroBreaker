using UnityEngine;

public class PanelSettings : Panel
{
    [SerializeField] private ButtonSettingAudio _buttonSettingMusic;
    [SerializeField] private ButtonSettingAudio _buttonSettingEffect;

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

    private void LoadAudioSettings(ButtonSettingAudio buttonSettingAudio)
    {
        int maxVolueme = 1;
        int value = PlayerPrefs.GetInt(buttonSettingAudio.AudioName.ToString(), (int)buttonSettingAudio.AudioSource.volume);
        bool isEnable = value == maxVolueme;
        buttonSettingAudio.Init(isEnable);
    }

    private void Save(ButtonSettingAudio buttonSettingAudio)
    {
        PlayerPrefs.SetInt(buttonSettingAudio.AudioName.ToString(), (int)buttonSettingAudio.AudioSource.volume);
    }
}