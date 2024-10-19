using Enums;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlayGame : AbstractButton
{
    [SerializeField] private ScenesName _scenesName;
    [SerializeField] private SaveService _saveService;
    [SerializeField] private PanelFade _panelFade;

    public event Action Clicked;

    private LocationObject _locationObject;

    protected override void OnClick()
    {
        _saveService.SaveCurrentLocationName(_locationObject.Name.ToString());
        _panelFade.SetActive(false, LoadScene);
        Clicked?.Invoke();
    }

    public void Init(LocationObject locationObject)
    {
        _locationObject = locationObject;

        this.enabled = true;

        if (_locationObject.IsActive == false)
        {
            this.enabled = false;
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_scenesName.ToString());
    }
}