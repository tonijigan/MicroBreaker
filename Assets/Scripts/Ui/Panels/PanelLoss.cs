using System;
using Enums;
using SDK;
using Sound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PanelLoss : Panel
    {
        [SerializeField] private Button _buttonTryAgain;
        [SerializeField] private Button _buttonExit;
        [SerializeField] private TMP_Text _score;
        [SerializeField] private TMP_Text _bricksSmashed;
        [SerializeField] private SDKPromotionalVideo _promotionalVideo;
        [SerializeField] private SoundMusic _soundMusic;

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


        public override async void OnMove(bool isActive)
        {
            base.OnMove(isActive);
            await MovePanel(isActive);
        }

        public void Fill(string bricksSmashed, string score)
        {
            _bricksSmashed.text = bricksSmashed;
            _score.text = score;
        }

        private void OnClickRestart(string sceneName)
        {
            OnMove(false);
            _soundMusic.SetActive(false);
            Clicked?.Invoke(sceneName);
        }
    }
}