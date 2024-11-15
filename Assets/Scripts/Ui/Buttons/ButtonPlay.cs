using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : AbstractButton
{
    [SerializeField] private ScenesName _scenesName;
    [SerializeField] private PanelFade _panelFade;
    [SerializeField] private SoundMusic _soundMusic;

    protected override void OnClick()
    {
        _panelFade.SetActive(false, LoadScene);
        _soundMusic.SetActive(false);
    }

    private void LoadScene() => SceneManager.LoadScene(_scenesName.ToString());
}