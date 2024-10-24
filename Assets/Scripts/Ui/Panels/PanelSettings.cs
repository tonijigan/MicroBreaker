using DG.Tweening;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class PanelSettings : Panel
{
    [SerializeField] private ButtonSettingAudio _buttonSettingMusic;
    [SerializeField] private ButtonSettingAudio _buttonSettingEffect;
    [SerializeField] private RectTransform _rectTransformButtons;
    [SerializeField] private Panel _backGround;
    [SerializeField] private float _topPositionY;
    [SerializeField] private float _middlePositionY;
    [SerializeField] private float _tweenDuration;

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
        base.Move(isActive);

        if (_backGround != null)
            _backGround.Move(isActive);

        await MoveButton(isActive);
    }

    private async Task MoveButton(bool isActive)
    {
        if (isActive)
            await _rectTransformButtons.DOAnchorPosY(_middlePositionY, _tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
        else
            await _rectTransformButtons.DOAnchorPosY(_topPositionY, _tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
    }

    private void LoadAudioSettings(ButtonSettingAudio buttonSettingAudio)
    {
        int maxVolume = 1;
        int value = PlayerPrefs.GetInt(buttonSettingAudio.AudioName.ToString());
        bool isEnable = value == maxVolume;
        buttonSettingAudio.Init(isEnable);
    }

    private void Save(ButtonSettingAudio buttonSettingAudio)
    {
        int value = (int)buttonSettingAudio.AudioSources.First().volume;
        PlayerPrefs.SetInt(buttonSettingAudio.AudioName.ToString(), value);
    }
}