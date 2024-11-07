using Enums;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlayGame : AbstractButton
{
    [SerializeField] private ScenesName _scenesName;
    [SerializeField] private PanelFade _panelFade;

    public event Action Clicked;

    protected override void OnClick()
    {
        _panelFade.SetActive(false, LoadScene);
        Clicked?.Invoke();
    }

    private void LoadScene() => SceneManager.LoadScene(_scenesName.ToString());
}