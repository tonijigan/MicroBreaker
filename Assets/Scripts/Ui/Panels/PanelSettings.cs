using UnityEngine;

public class PanelSettings : Panel
{
    private const int MinVolume = 0;

    [SerializeField] private ButtonSettingAudio _buttonSettingMusic;
    [SerializeField] private ButtonSettingAudio _buttonSettingEffect;
    [SerializeField] private Panel _backGround;

    private float _currentVolume;

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
        _currentVolume = PlayerPrefs.GetFloat(buttonSettingAudio.AudioName.ToString());
        bool isEnable = _currentVolume == buttonSettingAudio.MaxVolume;
        buttonSettingAudio.Init(isEnable);
    }

    private void Save(ButtonSettingAudio buttonSettingAudio)
    {
        _currentVolume = buttonSettingAudio.IsEnable ? buttonSettingAudio.MaxVolume : MinVolume;
        PlayerPrefs.SetFloat(buttonSettingAudio.AudioName.ToString(), _currentVolume);
    }
}