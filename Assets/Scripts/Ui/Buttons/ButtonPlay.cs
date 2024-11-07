using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : AbstractButton
{
    [SerializeField] private ScenesName _scenesName;
    [SerializeField] private PanelFade _panelFade;

    protected override void OnClick() => _panelFade.SetActive(false, LoadScene);

    private void LoadScene() => SceneManager.LoadScene(_scenesName.ToString());
}