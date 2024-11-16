using Enums;
using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ButtonPlay : AbstractButton
    {
        [SerializeField] private ScenesName _scenesName;
        [SerializeField] private PanelFade _panelFade;
        [SerializeField] private SoundMusic _soundMusic;

        protected override void OnClick()
        {
            _panelFade.SetActive(false, OnLoadScene);
            _soundMusic.SetActive(false);
        }

        private void OnLoadScene() => SceneManager.LoadScene(_scenesName.ToString());
    }
}