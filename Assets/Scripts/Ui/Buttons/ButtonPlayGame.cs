using System;
using Enums;
using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ButtonPlayGame : AbstractButton
    {
        [SerializeField] private ScenesName _scenesName;
        [SerializeField] private PanelFade _panelFade;
        [SerializeField] private SoundMusic _soundMusic;

        public event Action Clicked;

        protected override void OnClick()
        {
            _panelFade.SetActive(false, LoadScene);
            _soundMusic.SetActive(false);
            Clicked?.Invoke();
        }

        private void LoadScene() => SceneManager.LoadScene(_scenesName.ToString());
    }
}