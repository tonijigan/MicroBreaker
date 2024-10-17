using Enums;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlayGame : AbstractButton
{
    [SerializeField] private ScenesName _scenesName;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private SaveService _saveService;
    [SerializeField] private PanelFade _panelFade;

    public event Action Clicked;

    private LocationObject _locationObject;

    protected override void OnClick()
    {
        _saveService.SaveCurrentLocationName(_locationObject.Name.ToString());
        _panelFade.SetActive(false, LoadScene);
    }

    public void Init(LocationObject locationObject)
    {
        _locationObject = locationObject;

        this.enabled = true;
        _text.text = "���� ������";

        if (_locationObject.IsActive == false)
        {
            _text.text = "��� �������";
            this.enabled = false;
        }

        Clicked?.Invoke();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_scenesName.ToString());
    }
}