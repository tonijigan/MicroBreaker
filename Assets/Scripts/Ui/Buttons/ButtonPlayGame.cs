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

    public event Action Clicked;

    private LocationObject _locationObject;

    protected override void OnClick()
    {
        _saveService.SaveCurrentLocationName(_locationObject.Name.ToString());
        SceneManager.LoadScene(_scenesName.ToString());
    }

    public void Init(LocationObject locationObject)
    {
        _locationObject = locationObject;

        this.enabled = true;
        _text.text = "еярэ днярсо";

        if (_locationObject.IsActive == false)
        {
            _text.text = "мер днярсою";
            this.enabled = false;
        }

        Clicked?.Invoke();
    }
}