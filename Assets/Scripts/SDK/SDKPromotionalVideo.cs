using System;
using Agava.YandexGames;
using UI;
using UnityEngine;

namespace SDK
{
    public class SDKPromotionalVideo : MonoBehaviour
    {
        private const int MinValue = 0;
        private const int MaxValue = 1;

        [SerializeField] private FocusTracking _focusTracking;

        public event Action ClosedCallBack;

        public void ShowInterstitialAd() => InterstitialAd.Show(OnOpenCallBack, OnCloseCallBack);

        private void OnOpenCallBack()
        {
            Time.timeScale = MinValue;
            _focusTracking.enabled = false;
            AudioListener.pause = true;
        }

        private void OnCloseCallBack(bool wasShown)
        {
            Time.timeScale = MaxValue;
            _focusTracking.enabled = true;
            AudioListener.pause = false;
            ClosedCallBack();
        }
    }
}