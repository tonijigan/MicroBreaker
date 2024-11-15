using Enums;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelWin : Panel
{
    [SerializeField] private Button _buttonTryAgain;
    [SerializeField] private Button _buttonContinue;
    [SerializeField] private PanelFade _panelFade;
    [SerializeField] private TMP_Text _time;
    [SerializeField] private TMP_Text _bricksSmashed;
    [SerializeField] private TMP_Text _credits;
    [SerializeField] private SoundMusic _soundMusic;

    public event Action<string> Clicked;

    private void OnEnable()
    {
        _buttonTryAgain.onClick.AddListener(() => { OnClick(ScenesName.Game.ToString()); });
        _buttonContinue.onClick.AddListener(() => { OnClick(ScenesName.ChooseLevel.ToString()); });
    }

    private void OnDisable()
    {
        _buttonTryAgain.onClick.RemoveListener(() => { OnClick(ScenesName.Game.ToString()); });
        _buttonContinue.onClick.RemoveListener(() => { OnClick(ScenesName.ChooseLevel.ToString()); });
    }

    public void Fill(string time, string bricksSmashed, string credits)
    {
        _time.text = time;
        _bricksSmashed.text = bricksSmashed;
        _credits.text = credits;
    }

    public override async void Move(bool isActive)
    {
        base.Move(isActive);
        await MovePanel(isActive);
    }

    private async void OnClick(string sceneName)
    {
        _panelFade.SetActive(false);
        _soundMusic.SetActive(false);
        base.Move(false);
        await MovePanel(false, () => Clicked?.Invoke(sceneName));
    }
}