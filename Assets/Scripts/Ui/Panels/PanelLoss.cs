using Enums;
using SDK;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelLoss : Panel
{
    [SerializeField] private Button _buttonTryAgain;
    [SerializeField] private Button _buttonExit;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _bricksSmashed;
    [SerializeField] private SDKPromotionalVideo _promotionalVideo;

    public event Action<string> Clicked;

    private void OnEnable()
    {
        _buttonTryAgain.onClick.AddListener(() => { _promotionalVideo.ShowInterstitialAd(); });
        _buttonExit.onClick.AddListener(() => { OnClickRestart(ScenesName.StartScene.ToString()); });
        _promotionalVideo.ClosedCallBack += () => { OnClickRestart(ScenesName.Game.ToString()); };
    }

    private void OnDisable()
    {
        _buttonTryAgain.onClick.RemoveListener(() => { _promotionalVideo.ShowInterstitialAd(); });
        _buttonExit.onClick.RemoveListener(() => { OnClickRestart(ScenesName.StartScene.ToString()); });
        _promotionalVideo.ClosedCallBack -= () => { OnClickRestart(ScenesName.Game.ToString()); };
    }


    public override async void Move(bool isActive)
    {
        base.Move(isActive);
        await MovePanel(isActive);
    }

    public void Fill(string bricksSmashed, string score)
    {
        _bricksSmashed.text = bricksSmashed;
        _score.text = score;
    }

    private void OnClickRestart(string sceneName)
    {
        Move(false);
        Clicked?.Invoke(sceneName);
    }
}